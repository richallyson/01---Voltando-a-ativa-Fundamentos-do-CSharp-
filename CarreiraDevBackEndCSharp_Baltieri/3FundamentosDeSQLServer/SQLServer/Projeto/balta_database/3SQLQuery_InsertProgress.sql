SELECT * FROM [Course]
SELECT * FROM [Student]
SELECT * FROM [StudentCourse]

--SELECT NEWID()

INSERT INTO 
    [Student]([Id], [Name], [Email], [Document], [Phone], [Birthdate], [CreateDate])
VALUES(
    '19e25db1-87b7-4894-8f69-aced00ab238b',
    'Fartigeldo Penegalhas',
    'penegalhas@gmail.com',
    '12345678978',
    '99999999999',
    NULL,
    GETDATE()
)

INSERT INTO 
    [StudentCourse]([CourseId], [StudentId], [Progress], [Favorite], [StartDate], [LastUpdateDate])
VALUES(
    '5b65e125-4b0d-e73d-3c30-4baa00000000',
    '19e25db1-87b7-4894-8f69-aced00ab238b',
    2,
    1,
    '2020-04-15 10:52:37',
    GETDATE()
)