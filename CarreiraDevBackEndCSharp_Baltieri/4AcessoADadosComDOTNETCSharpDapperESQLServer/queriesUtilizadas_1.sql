
SELECT * FROM [Student]
SELECT * FROM [StudentCourse]
SELECT * FROM [Category]
SELECT * FROM [Course]
SELECT * FROM [Career] WHERE [Id] IN ('01ae8a85-b4e8-4194-a0f1-1c6190af54cb', '92d7e864-bea5-4812-80cc-c2f4e94db1af')

INSERT INTO 
    [Student] 
VALUES
    (NEWID(), 'Guts', 'guts@berserk.com', '11111111111', '1111111111111', '10-07-1991 22:45:00', GETDATE())

--CREATE OR ALTER PROCEDURE [spGetCoursesByCategory]
--    @CategoryId UNIQUEIDENTIFIER
--AS
--    SELECT * FROM [Course] WHERE [CategoryId] = @CategoryId

SELECT 
    [Career].[Id],
    [Career].[Title],
    [CareerItem].[CareerId],
    [CareerItem].[Title] 
FROM 
    [Career] INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
ORDER BY
    [Career].[Title]
