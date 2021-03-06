﻿DotCustomer
===========

API for management of Customers

T-SQL Script
============

DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'DotCustomer.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201505302109086_Initial'
BEGIN
    CREATE TABLE [dbo].[DotCustomerCustomerAddress] (
        [Id] [int] NOT NULL IDENTITY,
        [Title] [nvarchar](max),
        [FirstName] [nvarchar](max),
        [LastName] [nvarchar](max),
        [Company] [nvarchar](max),
        [Street] [nvarchar](max),
        [StreetNumber] [nvarchar](max),
        [City] [nvarchar](max),
        [Zip] [nvarchar](max),
        [Country] [nvarchar](max),
        [State] [nvarchar](max),
        [Province] [nvarchar](max),
        [Email] [nvarchar](max),
        [Phone] [nvarchar](max),
        [SubscribedToNewsletter] [bit] NOT NULL,
        CONSTRAINT [PK_dbo.DotCustomerCustomerAddress] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[DotCustomerCustomer] (
        [Id] [int] NOT NULL IDENTITY,
        [Email] [nvarchar](max),
        [Password] [nvarchar](max),
        [FirstName] [nvarchar](max),
        [LastName] [nvarchar](max),
        [BillingAddress_Id] [int],
        [ShippingAddress_Id] [int],
        CONSTRAINT [PK_dbo.DotCustomerCustomer] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_BillingAddress_Id] ON [dbo].[DotCustomerCustomer]([BillingAddress_Id])
    CREATE INDEX [IX_ShippingAddress_Id] ON [dbo].[DotCustomerCustomer]([ShippingAddress_Id])
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD CONSTRAINT [FK_dbo.DotCustomerCustomer_dbo.DotCustomerCustomerAddress_BillingAddress_Id] FOREIGN KEY ([BillingAddress_Id]) REFERENCES [dbo].[DotCustomerCustomerAddress] ([Id])
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD CONSTRAINT [FK_dbo.DotCustomerCustomer_dbo.DotCustomerCustomerAddress_ShippingAddress_Id] FOREIGN KEY ([ShippingAddress_Id]) REFERENCES [dbo].[DotCustomerCustomerAddress] ([Id])
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201505302109086_Initial', N'DotCustomer.Migrations.Configuration',  0x1F8B0800000000000400ED5BDD6EDB3614BE1FB0771074B50DA995A4375B60B7489D6430D6FC204E8B6137052D1D3BC4284A23A934C6B027DBC51E69AFB0A35F5394644B96EDB545D19B9822BF73F8E9F0F0FCA8FFFEFDCFF0F5B3CFAC271092067C649F0C8E6D0BB81B78942F4676A4E62F7EB45FBFFAF69BE1A5E73F5BEFF3792FE379B892CB91FDA85478E638D27D049FC8814F5D11C860AE066EE03BC40B9CD3E3E39F9C93130710C2462CCB1ADE475C511F921FF8731C7017421511761D78C064368E4FA609AA75437C90217161645F046A1C4915F82006133E17442A11B92A1230B84450B5BC1238F963207EB7AD7346096A380536B72DC279A08842FDCFDE49982A11F0C534C401C21E9621E0BC396112B27D9DADA6B7DDE2F169BC4567B5308772137D3B029EBCCC3873CCE55B316F179C22AB2951F1AE136647F6E53CE7F4DCF30448695BA6D4B33113F18A2E6F20FD4D410E2A028E2C0DE6A8B02C34C0F8DF91358E588C38E2102941D8917517CD18757F81E543F03BF0118F18D3F784BBC267A5011CBA134108422DEF619EED74E2D996535EE7980B8B65DA9A74EB13AE5E9EDAD60D0A27330685C968344D5520E067E0208802EF8E280582C718907053916EC87AA08A412E0E8D14CFA16D5D93E7B7C017EA7164E39FB675459FC1CB473215DE718AC71617E1CB804D52AEA8902AFE73EF92DE9203091A077E48F872EF721018401D48CC4DE4CF40EC9FBBC430F72CE4371A1EC008F062118730023CDC7B97823F9F28DE8C7B1774E913CAF6BF9DC780EF7F2FD368265D4167E03D0437F05132883D702EF64D103020BCC685EBA843677543B6BC37F777617EBD29FF57A32552E29BF1BE5EC92D04DD9027BA485EAE21F20D650C6514C1E53DB0649A7CA4611A9F6B06FFC19C7D2502FF3E60A5F3664CFA300D229178CA60D3CC072216F105DE56F729EA18B657BE32BD567B63D63AF5CDA975FA3739AC7329039726DA563C964973998E4BEE59AD394FCDA84C04DA133A261AA22B42C546F60F15C6DB88C8375B2BA2A0B82CE978303831E9D18868CD8FF9265B68DFF85A77C850933DEC89A2D4B030435784A2ABCE68BA98D55C78985667779ECC1C84B99D186A0A2A8FD6CA4A02AAB932E3E6AD5448AA475D8F5681D1B6BFC25AE394B4F91B3D9879D976395CC5F64A3B73B681CC2DA506527B05E69D5F26A61B691567B896B5B507AEEB91EBC35BD311DB1171B9B72E0ED5AADEE5A405AFBC30E63454C686D7245150AB946523D6342D938D5F4CBBD789FC14C371654DB9A8D0B69084F11B5980F1344EC23C48A2990BA2C88CC461C3D8F32BD3D085341CE45C409397A8BEC3FC98E72BE3BF3347D521F6AEB81A43D08A655CB4F0314C4D3800CD2C5A6024554DC288A8899DC7018B7CDE147FAF5B9DD58D74806CA83D861682EA38DA707BAC5590A943AD46DB2315851D1DA8186C8F93176E74987CAC2B4A5E97A962E54F3AEC2FC9754A9BABC97ED6212495151D2019E8C270563529339C0D76E126A98A94494986DA63AC6A1E3ACC6AB43D52961FEA30D950076DD29245499574A8032B0D0589124D0D73AA52868EE1824C67E854BCA1712D996EB693133E80F3EDE5750FE56E77625C4569A1645FC5E8E7E2B8F76D92E538AA6C976B02F49E6658C16B6F74715069DACBA6A0BCCA6A2BAB35C0EA8C38A6B750A78FA65964BDA5A69D55C350D1A349663E917119B1A84175DABF1986F7B1B04A36D3D7C42A80BBB2B1860466CB5767A2EDD6CA1A12B84FCACC3633B0D9CE2A599F39A5F0A345F6676479C32CE3DAFC914425054BA7D85612487971FA355D4A05FE209E3098FEC1C68CA2E75E4DB8269CCE41AAB487609F1E9F9C1ADF537C3ADF3638527AACEB070E07EF88D098DE8D3D8FB57DA90D9F0BF02722DC4722BEF3C9F3F73AD456FD875E68668FA11798D1DAEF85556EDFEF00AADCA2EFB74FAD0DDF0B486BB5F724BED44EEFC996D632EF8564B6C57B8195BA88FDD4D2DBDBFDA85ADBC29E51B587F6F597E10E77F8368DBEEF97EA5B6B0268EDFD545A3C13EEC1F3C8FE33597D664D7E359384897764DD0A0C20CEAC63EBAFCE965F13677553A78AD05E9FC374514BD9C3F60DBB06F4AD7B8D78AE41C4C78E308C50317DC118B592C9DF0974BC3424AC7157D5B0BD8DE388B92FB0CD271710028F3D4275B36DA4B54A910B19863FDBC4CAA13ACB5F8DE6B046D32EE5DDB9D5D437DBAB0DB5F51DF01AC368D3574F73C491EDCD023488D4496A758DAE7D78DD8ED636E25BCAFDE43AF606B90DFDBF762DE70690CFAD1BFF6951D2A1CF5EADACE029D6FE930AFA1349172B88B86CC4C12D9DDF62CE84CF83DCA5181AE5538CB8E71A14F1F0709F0B45E7C455F8D845A692CFF2DE131625A12DE603137E1BA93052B865F067ACD49D8BDDD13AF9C9C704659D87B761F221DB2EB6806A52DC02DCF23711655EA1F7554D7ED20011FBB92C1988DFA58A9382C5B240BAA934DE9A8032FA0AF7FC007EC8104CDEF22979826D747B27E12D2C88BBCC0B64CD209B5F4499F6E105250B417C9961ACD6E34FB461CF7F7EF51F74D9AB31AB350000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201505311936242_Initial2'
BEGIN
    IF object_id(N'[dbo].[FK_dbo.DotCustomerCustomer_dbo.DotCustomerCustomerAddress_BillingAddress_Id]', N'F') IS NOT NULL
        ALTER TABLE [dbo].[DotCustomerCustomer] DROP CONSTRAINT [FK_dbo.DotCustomerCustomer_dbo.DotCustomerCustomerAddress_BillingAddress_Id]
    IF object_id(N'[dbo].[FK_dbo.DotCustomerCustomer_dbo.DotCustomerCustomerAddress_ShippingAddress_Id]', N'F') IS NOT NULL
        ALTER TABLE [dbo].[DotCustomerCustomer] DROP CONSTRAINT [FK_dbo.DotCustomerCustomer_dbo.DotCustomerCustomerAddress_ShippingAddress_Id]
    IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_BillingAddress_Id' AND object_id = object_id(N'[dbo].[DotCustomerCustomer]', N'U'))
        DROP INDEX [IX_BillingAddress_Id] ON [dbo].[DotCustomerCustomer]
    IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_ShippingAddress_Id' AND object_id = object_id(N'[dbo].[DotCustomerCustomer]', N'U'))
        DROP INDEX [IX_ShippingAddress_Id] ON [dbo].[DotCustomerCustomer]
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Title] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Company] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Street] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [StreetNumber] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [City] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Zip] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Country] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [State] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Province] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Phone] [nvarchar](max)
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [SubscribedToNewsletter] [bit] NOT NULL DEFAULT 0
    DECLARE @var0 nvarchar(128)
    SELECT @var0 = name
    FROM sys.default_constraints
    WHERE parent_object_id = object_id(N'dbo.DotCustomerCustomer')
    AND col_name(parent_object_id, parent_column_id) = 'BillingAddress_Id';
    IF @var0 IS NOT NULL
        EXECUTE('ALTER TABLE [dbo].[DotCustomerCustomer] DROP CONSTRAINT [' + @var0 + ']')
    ALTER TABLE [dbo].[DotCustomerCustomer] DROP COLUMN [BillingAddress_Id]
    DECLARE @var1 nvarchar(128)
    SELECT @var1 = name
    FROM sys.default_constraints
    WHERE parent_object_id = object_id(N'dbo.DotCustomerCustomer')
    AND col_name(parent_object_id, parent_column_id) = 'ShippingAddress_Id';
    IF @var1 IS NOT NULL
        EXECUTE('ALTER TABLE [dbo].[DotCustomerCustomer] DROP CONSTRAINT [' + @var1 + ']')
    ALTER TABLE [dbo].[DotCustomerCustomer] DROP COLUMN [ShippingAddress_Id]
    DROP TABLE [dbo].[DotCustomerCustomerAddress]
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201505311936242_Initial2', N'DotCustomer.Migrations.Configuration',  0x1F8B0800000000000400CD59CB6EE33614DD17E83F085AB540C6CA63D306F20C327652044D9C60E4CCA23B5ABA7688A14895A432F1B7CDA29FD45FE8A59E94643B5614078537D61579EE8314CFB9D2BF3FFEF13F3DC7CC7902A9A8E063F76474EC3AC0431151BE1ABBA95E7EF8CDFDF4F1E79FFCCB287E76BE96E3CECC389CC9D5D87DD43A39F73C153E424CD428A6A1144A2CF52814B14722E19D1E1FFFEE9D9C7880102E62398EFF25E59AC6905DE0E544F010129D12762B2260AAB0E39D204375662406959010C6EE54E849AAB488418EAEF95212A5651AEA54C2E81241F5FA4AE2E0EF427E739D0B46094618005BBA0EE15C68A231FEF30705819682AF82040D84CDD709E0B825610A8ABCCEEBE1FBA6787C6A52F4EA89255498C5DB13F0E4ACA899D79EFEAACABB554DB1AA79A14CD65965C7EEE5B2ACA9EBB4DD9D4F983443FB943EBFA6A04635F29163CD3FAAF6126E39F33B7226293350630EA996841D39F7E982D1F04F58CFC537E0639E3266678179E0BD86014DF7522420F5FA0B2C8BDCAE23D7F19AF3BCF6C46A9A3527CFF99AEBB353D799A173B260506D12AB3E811612FE000E926888EE89D620B9C180AC281DEF2D5F9731A1AC7487DB129F3CD7B925CF37C057FA71ECE25FD7B9A2CF1095962284074EF141C549B80AF092977BA214AE4C74704773AA191CDCCB15954A9BBF07F77443DEC9D144C409E1EB83FB416000FD4E6E6669BC3087CAA16B973D670776F2174DDE61132033CAF7D80478561DFED091E28922B51FDED1A3E087F712A40B154ABA80682E66F05D3130477DE9F6B3100C08DFC01536AAEFD5E4DBA56414429A506492C2E374B1818F51BD1494AC8AB89B51E75001E8724F159CAB5CA7F69DABA2914DFC9BC2AC02AA2599976BB252BB795BC49B7F4B9204D7C1127385C509722537F910F49732718EE1856A83A2A9A2AD3C21359315B4EE9AC72C828C42A6449305318B3489E2CE302CFF96D2960EDA156ECB91BAE0E50CF3BF58DC1E72AA5EA69687BAAC387A15A3E4C892862AD286B8EB4CCE243661446E104013C1D2986F1351BB661792C606284CFB63D482C586A9ADFB23158AC486294CFB63587AC3C6B1CCFB63D58AC286AAADFB235592C106AA8CFBE39492C086296D7D514AC6EF6295777AE497D17A23B90D827A1742C6D9364066E853E1828F9B152E8C7D6A93F16DB32899A9C71351B169E389A8AC3D9072BA6CC0E4A61E196D21C3468A5BC674BDF85EEB146B1FA45EE7246DB574EDA3791799B58754DE2B526B91975F10C9CBAF273ACC920F719D6C9D22C32AC15A69884766C028F89B4D18C57CEB01B784D325289D77BDEEE9F1C969EB4DC6FFE7AD82A754C4F67EB5F0EECD3B35757DB13DDFA9D75EE8D7F91391E12391BFC4E4F9571BEA353DF920B046DF3D08A9D35B0F426BF7CF83C05A3DF220AC661FFC0650CD5E77589E563F3B08C8EA590716BED1970EAC96D57B0E7B805AFDE53030BB871C96E0CE3E7141F59BF688DD5E66773B68B77C3BFBC19CB9C66EB410187B1EADD5B30C6E1CBB9CEA7BF687017F0A8AAE6A08F399804368C8AA062DC7600325CA65C05CED88CA21AD55BA054D222CD985D47449428DB743502A7B75F095B0343BEA710DAFF95DAA93545F2805F18235649FEFEDF69F75C7CD98FDBBC45CA9B74801C3A49802DCF1CF29655115F7D5863DB505C2EC9E821C312A3CC8106EB5AE90661D55B80DA828DF1412E0865AE710270CC1D41D0FC813BC26B6070537B022E1BA9446DB415E5E8866D9FD29252B6CAF558151CF371FBB3CF3B5EBE37FAFE62CA41F1B0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201506011653209_Disabled'
BEGIN
    ALTER TABLE [dbo].[DotCustomerCustomer] ADD [Disabled] [bit] NOT NULL DEFAULT 0
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201506011653209_Disabled', N'DotCustomer.Migrations.Configuration',  0x1F8B0800000000000400CD594B6FDB3810BE2FB0FF41D06917482D27B9EC06728BD44E16C1E6852AE9A1375A1A3B4429524B5269FCDB7AD89FB47F61877A52925F8AEAA0F0C51A0DBF79F031DF50FF7DFFD7FFF01233E719A4A2824FDCE3D1D875808722A27C397153BD78F787FBE1FDAFBFF81751FCE27C2EF54E8D1E8EE46AE23E699D9C799E0A9F20266A14D3500A25167A148AD82391F04EC6E33FBDE3630F10C2452CC7F13FA55CD318B2077C9C0A1E42A253C26E44044C15727C1364A8CE2D8941252484893B137A9A2A2D6290A32BBE90446999863A9530BA4050BDBA94A8FC4DC8AFAE73CE28410F03600BD7219C0B4D34FA7FF6A820D052F06590A080B0875502A8B7204C4111D759ADBE6F88E31313A2570F2CA1C2CCDF9E80C7A745CEBCF6F05765DEAD728A59CD1365A2CE323B712F16654E5DA76DEE6CCAA451ED93FAFC99821AD5C8478E35FEA85A4BB8E4CCEFC899A6CC404D38A45A1276E4DCA77346C3BF61F520BE029FF094313B0A8C03DF350428BA972201A9579F6051C47615B98ED71CE7B50756C3AC3179CC575C9F9EB8CE2D1A277306D522B1F2136821E12FE0208986E89E680D921B0CC892D2B1DEB2751113CA4A73B82C71E7B9CE0D79B906BED44F1317FFBACE257D81A894142E3C728A1B1507E12CC02E2BF744299C99E8E0861EA86670702B97542A6DFE1EDCD23579234353112784AF0E6E078101F41B99B94DE3B939540E9DBB6C9F1DD8C8179ABCC122C0CA28DF6211E05975F843478A678AA5FDF0869E043FBC95209DAB50D239440FE216BE2906E6A82FCD7E148201E16B6AC576D41955463BEA87E37B7511EF967624549A50AC48A58DF99ABA8E2CA828EDAA88BFE9670E15802ED76651BB95EBD4B6737635B209C43A372B876A6AE7E5DCAEE480DE0612E8DF9024C1F9B448612171829C114EDF05FD29519C6378A15AC38C2A6F2B4B58E2C9125A6FCD768D202B4533A2C99C98499A4671470DD3BF21B5A5817686DBB4A64E7839C2FC2F26B7072DABA7A965A14E2B6A2F63A42E59D05079DA20899DC11955278CC835446A2A581AF34D646CDBE8821AD90085687F8C9AF8D830B5747FA482D9D83085687F0C8BB7D83896787FAC9A99D850B5747FA48A7AD84095707F9C925AD830A5AC2F4AC91CBA58E59B1EF165F4A011DC1A62BE0D21ABFD364026E893E1A2AE37335C08FBE426ABDBCDA464A21E3BA2AACA8D1D51497B20E565B701938B7A44B4A1A83642DCA0B3BF95BAC8DAB8B5B48BE47BADF3B07D247B9D33B9D564B60FF96D65B1AD5259AFCA63AB0CFA4549DA7D61D2A951B98AEB64331E99FA14AC948678641446C13F6CCA28C65B2BDC104E17A074DE87BB27E3E393D6DDCACF73CFE12915B1BD2F3BDEFC3A819ABCEEBC30E8C9201B3708FC99C8F089C8DF62F2F2BB0DF59A5B8241608D9B8041489D6E7F105ABBA31F04D6EADA0761353BF31F00D5ECBE87C56975D88380AC2E7A60E21B9DF2C06C59DDF0B00DD4EA788781D95DEDB000B776AE73AA0777ADBB31FA75ACDDCE6A7B736A37A05BBBD3BCFA4DDC682ED0F7DC5BAB831ADCC676EBB2EFD99F3BFC1928BAAC21CCC70F0EA129783568A983ED9C28138FB1DA1E952AAD79B9014D224CD9B9D47441428DAF43502ABB10F94C589A950B5C0757FC2ED549AACF958278CE1A24D4F7B6DBCF7AF5A6CFFE5D629ED48F0801DDA41802DCF18F296551E5F7E59A35B501C2AC9EA2C0A257781822DC725521DD7638EA26A0227D3348809BF2FC0071C2104CDDF1803CC36B7C7B54700D4B12AE4A7AB51964F74434D3EECF285962B3AF0A8C7ABCF984E7996F78EFFF07FD597463F51B0000 , N'6.1.3-40302')
END

