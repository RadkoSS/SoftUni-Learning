﻿namespace P01.VillainNames;

internal static class SqlQueries
{
    public const string SelectVillainNames = @"SELECT v.Name,              COUNT(mv.VillainId) 
                    AS MinionsCount  
                  FROM Villains AS v 
                  JOIN MinionsVillains 
                    AS mv 
                    ON v.Id = mv.VillainId 
              GROUP BY v.Id, v.Name 
                HAVING COUNT(mv.VillainId) > 3 
              ORDER BY COUNT(mv.VillainId)";

    public const string SelectNameById = @"SELECT Name FROM Villains WHERE Id = @Id";

    public const string SelectMinionsById = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

    public const string DeleteFromMappingTableById = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";

    public const string DeleteFromVillainsById = @"DELETE FROM Villains
      WHERE Id = @villainId";
}