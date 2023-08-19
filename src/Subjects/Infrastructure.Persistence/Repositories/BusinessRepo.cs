using CSharpFunctionalExtensions;
using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Goodtocode.Subjects.Persistence.Repositories;

public class BusinessRepo : IBusinessRepo
{
    private readonly ISubjectsDbContext _context;

    public BusinessRepo(ISubjectsDbContext context)
    {
        _context = context;
    }

    public async Task<Result<BusinessEntity?>> GetBusinessByKeyAsync(Guid businessKey, CancellationToken cancellationToken)
    {
        var businessResult = await _context.Business.FindAsync(new object?[] { businessKey, cancellationToken }, cancellationToken: cancellationToken);
        if (businessResult != null)
            return Result.Success<BusinessEntity?>(businessResult);
        else
            return Result.Failure<BusinessEntity?>("Business not found.");
    }

    public async Task<Result<PagedResult<BusinessEntity>>> GetBusinessesAllAsync(string businessName, int page, int results, CancellationToken cancellationToken)
    {
        var businessResult = await _context.Business.AsNoTracking()
            .OrderBy(b => b.BusinessKey)
            .GetPagedAsync(page, results, cancellationToken);
        return Result.Success(businessResult);
    }

    public async Task<Result<PagedResult<BusinessEntity>>> GetBusinessesByNameAsync(string businessName, int page, int results, CancellationToken cancellationToken)
    {
        var businessResult = await _context.Business.AsNoTracking()
            .Where(b => b.BusinessName.Contains(businessName))
            .OrderBy(b => b.BusinessKey)
            .GetPagedAsync(page, results, cancellationToken);
        return Result.Success(businessResult);
    }

    public async Task<Result<BusinessEntity>> AddBusinessAsync(IBusinessObject businessInfo, CancellationToken cancellationToken)
    {
        if (businessInfo == null)
            return Result.Failure<BusinessEntity>("Cannot add. Business is null.");

        var businessEntity = new BusinessEntity
        {
            BusinessName = businessInfo.BusinessName,
            TaxNumber = businessInfo.TaxNumber
        };

        var businessResult = await _context.Business.AddAsync(businessEntity, cancellationToken);
        
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        when (e.InnerException?.InnerException is SqlException sqlEx &&
          (sqlEx.Number == 2601 || sqlEx.Number == 2627))
        {
            return Result.Failure<BusinessEntity>("Cannot add. Duplicate record exists.");
        }

        return Result.Success<BusinessEntity>(businessResult.Entity);
    }

    public async Task<Result> UpdateBusinessAsync(IBusinessEntity businessInfo, CancellationToken cancellationToken)
    {
        var businessResult = await _context.Business.FindAsync(new object?[] { businessInfo.BusinessKey, cancellationToken }, cancellationToken: cancellationToken);
        if (businessResult == null)
            return Result.Failure("Cannot update. Business not found.");
        businessResult.BusinessName = businessInfo.BusinessName;
        businessResult.TaxNumber = businessInfo.TaxNumber;
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> DeleteBusinessAsync(Guid businessKey, CancellationToken cancellationToken)
    {
        var businessResult = await _context.Business.FindAsync(new object?[] { businessKey, cancellationToken }, cancellationToken: cancellationToken);
        if (businessResult == null)
            return Result.Failure("Cannot delete. Business not found.");
        _context.Business.Remove(businessResult);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}