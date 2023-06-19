/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------*/
-- Master Data (this project is the only one updating the table x.)
:r .\Data\Master\EventGroup.sql
:r .\Data\Master\Gender.sql
:r .\Data\Master\RecordState.sql
:r .\Data\Master\SettingType.sql
:r .\Data\Master\TimeCycle.sql
-- Shared Data (multiple projects updating same table with different x.)
:r .\Data\Shared\DetailType.sql
:r .\Data\Shared\EventType.sql
:r .\Data\Shared\Flow.sql
:r .\Data\Shared\FlowSequence.sql
:r .\Data\Shared\FlowStep.sql
:r .\Data\Shared\FlowType.sql
:r .\Data\Shared\Module.sql
:r .\Data\Shared\Option.sql
:r .\Data\Shared\OptionGroup.sql
:r .\Data\Shared\Setting.sql
:r .\Data\Shared\SettingModule.sql
:r .\Data\Shared\TimeType.sql

-- Any environment specific changes go here
:r .\Environment\$(TargetEnvironment).sql

---- To be re-factored to "Enter your company name: " to generate records and basic test data
:r .\Data\GoodToCodeData.sql
