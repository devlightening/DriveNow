

INSERT INTO [DriveNowDb].[dbo].[SocialMedias]
(
    [SocialMediaId],
    [SocialMediaName],
    [SocialMediaUrl],
    [IconUrl]
)
VALUES
(NEWID(), 'Facebook', 'https://www.facebook.com/', 'https://example.com/icons/facebook.png'),
(NEWID(), 'Instagram', 'https://www.instagram.com/', 'https://example.com/icons/instagram.png'),
(NEWID(), 'X', 'https://x.com/', 'https://example.com/icons/x.png'),
(NEWID(), 'LinkedIn', 'https://www.linkedin.com/', 'https://example.com/icons/linkedin.png');