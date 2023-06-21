Use Admin
Set Transaction Isolation Level Read Uncommitted
SELECT TOP 100 --  FROM [Admin].[dbo].[IP2LOCATION-LITE-DB11] Where [Column 2] = 'US' and [Column 5] = 'Valhalla'
SELECT TOP 100 --  FROM [Admin].[dbo].[GeoLiteCity-Location] Where country= 'US' And city = 'Valhalla'
SELECT TOP 100 --  FROM [EntityData].[dbo].[PostalCode]

Use master
Select INET_NTOA()
--
-- Mine:99.111.28.101

-- ********************
-- **-- IP2Location ***
-- ********************
--http://ipinfodb.com/ip_dataEntity.php
--ip = ((A*256+B)*256+C)*256 + D
--74.125.45.100 = ((74*256+125)*256+45)*256 + 100 = 1249717604
-- DOES NOT WORK
--Key: 5698907256df529e3a2561a55297387f6e3ecf9e3c7874110886493d82a510d1
--http://api.ipinfodb.com/v3/ip-city/?key=5698907256df529e3a2561a55297387f6e3ecf9e3c7874110886493d82a510d1&ip=99.111.28.101
--http://api.ipinfodb.com/v3/ip-country/?key=5698907256df529e3a2561a55297387f6e3ecf9e3c7874110886493d82a510d1&ip=99.111.28.101
SElect *
From [Admin].[dbo].[IP2LOCATION-LITE-DB11]
Where [Column 0] >= '1668226048' And [Column 1] <=  '1668226048'
Select ((99*256+111)*256+28)*256 + 101

-- ********************
-- **-- GeoLite ***
-- ********************
-- http://www.maxmind.com/app/csv
--ipnum = 16777216*w + 65536*x + 256*y + z
--where
--IP Address = w.x.y.z
--The reverse of this formula is
--w = int ( ipnum / 16777216 ) % 256;
--x = int ( ipnum / 65536    ) % 256;
--y = int ( ipnum / 256      ) % 256;
--z = int ( ipnum            ) % 256;
--Where % is the mod operator.
--I.e. (24.24.24.24 ) 404232216 = 16777216*24 + 65536*24 + 256*24 + 24
Select 16777216*99 + 65536*111 + 256*28 + 101
Select	*
FROM [Admin].[dbo].[GeoLiteCity-Blocks] 
Where startipnum >= '1668226149' And EndIPNum <= '1668226149'

-- ********************
-- ***-- Works, but is PHP
-- ********************
--http://www.geoplugin.net/php.gp?ip=99.111.28.101--