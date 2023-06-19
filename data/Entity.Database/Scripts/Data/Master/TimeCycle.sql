--------------------------------------------------------------
-- TimeCycle - All common time cycles
--------------------------------------------------------------
-- TimeCycle
MERGE INTO [Entity].[TimeCycle] AS Target 
USING (VALUES     
    (N'00000000-0000-0000-0000-000000000000', N'Daily', 1, -1)
    ,(N'B55CDC94-F9B6-4A45-BA46-13574AB35FF4', N'Weekdays', 5, -1)
    ,(N'325F3E37-76E5-4070-8BF9-7486A2EB62D3', N'Weekends', 2, -1)
	,(N'F4C5AED5-4853-47E1-AA2C-A30F86F4A357', N'WeeklyDay', 7, -1)	
    ,(N'28C6DE9B-600A-45DC-90AE-01CB20CD9BA8', N'MonthDay', 31, -1)
    ,(N'07424BEE-9C82-4893-85F3-2B1F5A3E5A67', N'MonthlyDayOfWeek', 7, 4)
    ,(N'E9971F55-4715-4D23-8245-730575B74D1A', N'YearlyDayOfWeek', 7, 52)
	,(N'403E4772-655E-4129-87B3-058EDCF1E553', N'YearlyDay', 365, -1)
	)
AS Source ([TimeCycleKey], [TimeCycleName], [Days], [Interval])
	ON Target.[TimeCycleKey] = Source.[TimeCycleKey]
-- Update
WHEN MATCHED THEN 
	UPDATE SET [TimeCycleName] = Source.[TimeCycleName]
-- Insert 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT ([TimeCycleKey], [TimeCycleName], [Days], [Interval])
        VALUES (Source.[TimeCycleKey], Source.[TimeCycleName], Source.[Days], Source.[Interval])
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;