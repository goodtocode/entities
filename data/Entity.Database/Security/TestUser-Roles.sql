﻿--
-- ALTER ROLE
--
ALTER ROLE [db_datareader] ADD MEMBER [TestUser];
GO
ALTER ROLE [db_datawriter] ADD MEMBER [TestUser];
GO
ALTER ROLE [db_executor] ADD MEMBER [TestUser];
GO
GRANT CONNECT TO [TestUser]
GO
--GRANT CONNECT TO [Publish@goodtocode.com]
--GO