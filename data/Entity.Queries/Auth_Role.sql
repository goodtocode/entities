--
--Roles
--
-- Role Default
Select E.EventGroupName, R.RoleName, G.RoleGroupName
From [EntityData].Auth.RoleEventDefault RE
Left Join	[EntityData].[Entity].EventGroup E On E.EventGroupID = RE.EventGroupID
Left Join	[EntityData].Auth.RoleGroup G On RE.RoleGroupID = G.RoleGroupID
Left Join	[EntityData].Auth.Role R On RE.RoleID = R.RoleID
-- Role Event
Select E.EventName, R.RoleName, G.RoleGroupName
From [EntityData].Auth.RoleEvent RE
Left Join	[EntityData].[Entity].Event E On E.EventID = RE.EventID
Left Join	[EntityData].Auth.RoleGroup G On RE.RoleGroupID = G.RoleGroupID
Left Join	[EntityData].Auth.Role R On RE.RoleID = R.RoleID

-- Raw
Use EntityData
Select Top 10 * From [EntityData].Auth.RoleGroup
Select Top 10 * From [EntityData].Auth.Role
Select Top 10 * From [EntityData].Auth.RoleEvent
Select Top 10 * From [EntityData].Auth.RoleEventDefault


Select newid(), newid(), newid(), newid()