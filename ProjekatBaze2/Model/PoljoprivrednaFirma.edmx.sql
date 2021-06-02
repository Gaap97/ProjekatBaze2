
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2021 20:41:48
-- Generated from EDMX file: D:\Files\Faks\Baze2\Projekat\ProjekatBaze2\ProjekatBaze2\PoljoprivrednaFirma.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RadPoljoprivredneFirme];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [JMBG] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [DatumRodjenja] datetime  NOT NULL,
    [Zarada] float  NOT NULL
);
GO

-- Creating table 'Psenicas'
CREATE TABLE [dbo].[Psenicas] (
    [IdPsenice] int IDENTITY(1,1) NOT NULL,
    [KolicinaPsenice] float  NOT NULL,
    [Kvalitet] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TestKvalitetas'
CREATE TABLE [dbo].[TestKvalitetas] (
    [IdTesta] int IDENTITY(1,1) NOT NULL,
    [KapacitetTestera] float  NOT NULL
);
GO

-- Creating table 'Testiras'
CREATE TABLE [dbo].[Testiras] (
    [PsenicaIdPsenice] int  NOT NULL,
    [TestKvalitetaIdTesta] int  NOT NULL
);
GO

-- Creating table 'Prihvatas'
CREATE TABLE [dbo].[Prihvatas] (
    [PrijemnikJMBG] int  NOT NULL,
    [TestiraPsenicaIdPsenice] int  NOT NULL,
    [TestiraTestKvalitetaIdTesta] int  NOT NULL
);
GO

-- Creating table 'Silos'
CREATE TABLE [dbo].[Silos] (
    [IdSilosa] int IDENTITY(1,1) NOT NULL,
    [KapacitetSilosa] float  NOT NULL,
    [PopunjenKapacitetS] bit  NOT NULL,
    [Mlin_IdMlina] int  NULL,
    [Prihvata_PrijemnikJMBG] int  NULL,
    [Prihvata_TestiraPsenicaIdPsenice] int  NULL,
    [Prihvata_TestiraTestKvalitetaIdTesta] int  NULL,
    [Prekrupac_IdPrekrupaca] int  NULL
);
GO

-- Creating table 'Mlins'
CREATE TABLE [dbo].[Mlins] (
    [IdMlina] int IDENTITY(1,1) NOT NULL,
    [NazivMlina] nvarchar(max)  NOT NULL,
    [VlasnikMlina] nvarchar(max)  NOT NULL,
    [SilosIdSilosa] int  NULL
);
GO

-- Creating table 'Prekrupacs'
CREATE TABLE [dbo].[Prekrupacs] (
    [IdPrekrupaca] int IDENTITY(1,1) NOT NULL,
    [KapacitetPrekrupaca] float  NOT NULL,
    [PopunjenKapacitetP] bit  NOT NULL
);
GO

-- Creating table 'Posedujes'
CREATE TABLE [dbo].[Posedujes] (
    [MlinIdMlina] int  NOT NULL,
    [PrekrupacIdPrekrupaca] int  NOT NULL
);
GO

-- Creating table 'Brasnoes'
CREATE TABLE [dbo].[Brasnoes] (
    [IdBrasna] int IDENTITY(1,1) NOT NULL,
    [KolicinaBrasna] float  NOT NULL
);
GO

-- Creating table 'Pravis'
CREATE TABLE [dbo].[Pravis] (
    [PrekrupacIdPrekrupaca] int  NOT NULL,
    [BrasnoIdBrasna] int  NOT NULL
);
GO

-- Creating table 'Uzimas'
CREATE TABLE [dbo].[Uzimas] (
    [MagacionerJMBG] int  NOT NULL,
    [PraviPrekrupacIdPrekrupaca] int  NOT NULL,
    [PraviBrasnoIdBrasna] int  NOT NULL
);
GO

-- Creating table 'Skladistes'
CREATE TABLE [dbo].[Skladistes] (
    [IdSkladista] int IDENTITY(1,1) NOT NULL,
    [KapacitetSkladista] bit  NOT NULL,
    [PopunjenKapacitetSk] bit  NOT NULL,
    [Uzima_MagacionerJMBG] int  NULL,
    [Uzima_PraviPrekrupacIdPrekrupaca] int  NULL,
    [Uzima_PraviBrasnoIdBrasna] int  NULL
);
GO

-- Creating table 'Imas'
CREATE TABLE [dbo].[Imas] (
    [MlinIdMlina] int  NOT NULL,
    [SkladisteIdSkladista] int  NOT NULL,
    [Kamion_IdKamiona] int  NULL
);
GO

-- Creating table 'Kamions'
CREATE TABLE [dbo].[Kamions] (
    [IdKamiona] int IDENTITY(1,1) NOT NULL,
    [KapacitetKamiona] float  NOT NULL,
    [ImaVozaca] bit  NOT NULL,
    [Prevoznik_JMBG] int  NULL
);
GO

-- Creating table 'Radniks_Prijemnik'
CREATE TABLE [dbo].[Radniks_Prijemnik] (
    [ProsecanBrPrijema] float  NOT NULL,
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radniks_Odrzavatelj'
CREATE TABLE [dbo].[Radniks_Odrzavatelj] (
    [BrojOdrzavanihPrekrupaca] nvarchar(max)  NOT NULL,
    [TrenutnoZauzet] bit  NOT NULL,
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radniks_Magacioner'
CREATE TABLE [dbo].[Radniks_Magacioner] (
    [ProsecanBrUzimanja] nvarchar(max)  NOT NULL,
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'Radniks_Prevoznik'
CREATE TABLE [dbo].[Radniks_Prevoznik] (
    [ProsecanBrPrevoza] float  NOT NULL,
    [JMBG] int  NOT NULL
);
GO

-- Creating table 'OdrzavateljPoseduje'
CREATE TABLE [dbo].[OdrzavateljPoseduje] (
    [Odrzavateljs_JMBG] int  NOT NULL,
    [Posedujes_MlinIdMlina] int  NOT NULL,
    [Posedujes_PrekrupacIdPrekrupaca] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [JMBG] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [IdPsenice] in table 'Psenicas'
ALTER TABLE [dbo].[Psenicas]
ADD CONSTRAINT [PK_Psenicas]
    PRIMARY KEY CLUSTERED ([IdPsenice] ASC);
GO

-- Creating primary key on [IdTesta] in table 'TestKvalitetas'
ALTER TABLE [dbo].[TestKvalitetas]
ADD CONSTRAINT [PK_TestKvalitetas]
    PRIMARY KEY CLUSTERED ([IdTesta] ASC);
GO

-- Creating primary key on [PsenicaIdPsenice], [TestKvalitetaIdTesta] in table 'Testiras'
ALTER TABLE [dbo].[Testiras]
ADD CONSTRAINT [PK_Testiras]
    PRIMARY KEY CLUSTERED ([PsenicaIdPsenice], [TestKvalitetaIdTesta] ASC);
GO

-- Creating primary key on [PrijemnikJMBG], [TestiraPsenicaIdPsenice], [TestiraTestKvalitetaIdTesta] in table 'Prihvatas'
ALTER TABLE [dbo].[Prihvatas]
ADD CONSTRAINT [PK_Prihvatas]
    PRIMARY KEY CLUSTERED ([PrijemnikJMBG], [TestiraPsenicaIdPsenice], [TestiraTestKvalitetaIdTesta] ASC);
GO

-- Creating primary key on [IdSilosa] in table 'Silos'
ALTER TABLE [dbo].[Silos]
ADD CONSTRAINT [PK_Silos]
    PRIMARY KEY CLUSTERED ([IdSilosa] ASC);
GO

-- Creating primary key on [IdMlina] in table 'Mlins'
ALTER TABLE [dbo].[Mlins]
ADD CONSTRAINT [PK_Mlins]
    PRIMARY KEY CLUSTERED ([IdMlina] ASC);
GO

-- Creating primary key on [IdPrekrupaca] in table 'Prekrupacs'
ALTER TABLE [dbo].[Prekrupacs]
ADD CONSTRAINT [PK_Prekrupacs]
    PRIMARY KEY CLUSTERED ([IdPrekrupaca] ASC);
GO

-- Creating primary key on [MlinIdMlina], [PrekrupacIdPrekrupaca] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [PK_Posedujes]
    PRIMARY KEY CLUSTERED ([MlinIdMlina], [PrekrupacIdPrekrupaca] ASC);
GO

-- Creating primary key on [IdBrasna] in table 'Brasnoes'
ALTER TABLE [dbo].[Brasnoes]
ADD CONSTRAINT [PK_Brasnoes]
    PRIMARY KEY CLUSTERED ([IdBrasna] ASC);
GO

-- Creating primary key on [PrekrupacIdPrekrupaca], [BrasnoIdBrasna] in table 'Pravis'
ALTER TABLE [dbo].[Pravis]
ADD CONSTRAINT [PK_Pravis]
    PRIMARY KEY CLUSTERED ([PrekrupacIdPrekrupaca], [BrasnoIdBrasna] ASC);
GO

-- Creating primary key on [MagacionerJMBG], [PraviPrekrupacIdPrekrupaca], [PraviBrasnoIdBrasna] in table 'Uzimas'
ALTER TABLE [dbo].[Uzimas]
ADD CONSTRAINT [PK_Uzimas]
    PRIMARY KEY CLUSTERED ([MagacionerJMBG], [PraviPrekrupacIdPrekrupaca], [PraviBrasnoIdBrasna] ASC);
GO

-- Creating primary key on [IdSkladista] in table 'Skladistes'
ALTER TABLE [dbo].[Skladistes]
ADD CONSTRAINT [PK_Skladistes]
    PRIMARY KEY CLUSTERED ([IdSkladista] ASC);
GO

-- Creating primary key on [MlinIdMlina], [SkladisteIdSkladista] in table 'Imas'
ALTER TABLE [dbo].[Imas]
ADD CONSTRAINT [PK_Imas]
    PRIMARY KEY CLUSTERED ([MlinIdMlina], [SkladisteIdSkladista] ASC);
GO

-- Creating primary key on [IdKamiona] in table 'Kamions'
ALTER TABLE [dbo].[Kamions]
ADD CONSTRAINT [PK_Kamions]
    PRIMARY KEY CLUSTERED ([IdKamiona] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Prijemnik'
ALTER TABLE [dbo].[Radniks_Prijemnik]
ADD CONSTRAINT [PK_Radniks_Prijemnik]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Odrzavatelj'
ALTER TABLE [dbo].[Radniks_Odrzavatelj]
ADD CONSTRAINT [PK_Radniks_Odrzavatelj]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Magacioner'
ALTER TABLE [dbo].[Radniks_Magacioner]
ADD CONSTRAINT [PK_Radniks_Magacioner]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Radniks_Prevoznik'
ALTER TABLE [dbo].[Radniks_Prevoznik]
ADD CONSTRAINT [PK_Radniks_Prevoznik]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Odrzavateljs_JMBG], [Posedujes_MlinIdMlina], [Posedujes_PrekrupacIdPrekrupaca] in table 'OdrzavateljPoseduje'
ALTER TABLE [dbo].[OdrzavateljPoseduje]
ADD CONSTRAINT [PK_OdrzavateljPoseduje]
    PRIMARY KEY CLUSTERED ([Odrzavateljs_JMBG], [Posedujes_MlinIdMlina], [Posedujes_PrekrupacIdPrekrupaca] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PsenicaIdPsenice] in table 'Testiras'
ALTER TABLE [dbo].[Testiras]
ADD CONSTRAINT [FK_PsenicaTestira]
    FOREIGN KEY ([PsenicaIdPsenice])
    REFERENCES [dbo].[Psenicas]
        ([IdPsenice])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TestKvalitetaIdTesta] in table 'Testiras'
ALTER TABLE [dbo].[Testiras]
ADD CONSTRAINT [FK_TestKvalitetaTestira]
    FOREIGN KEY ([TestKvalitetaIdTesta])
    REFERENCES [dbo].[TestKvalitetas]
        ([IdTesta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestKvalitetaTestira'
CREATE INDEX [IX_FK_TestKvalitetaTestira]
ON [dbo].[Testiras]
    ([TestKvalitetaIdTesta]);
GO

-- Creating foreign key on [PrijemnikJMBG] in table 'Prihvatas'
ALTER TABLE [dbo].[Prihvatas]
ADD CONSTRAINT [FK_PrijemnikPrihvata]
    FOREIGN KEY ([PrijemnikJMBG])
    REFERENCES [dbo].[Radniks_Prijemnik]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TestiraPsenicaIdPsenice], [TestiraTestKvalitetaIdTesta] in table 'Prihvatas'
ALTER TABLE [dbo].[Prihvatas]
ADD CONSTRAINT [FK_TestiraPrihvata]
    FOREIGN KEY ([TestiraPsenicaIdPsenice], [TestiraTestKvalitetaIdTesta])
    REFERENCES [dbo].[Testiras]
        ([PsenicaIdPsenice], [TestKvalitetaIdTesta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestiraPrihvata'
CREATE INDEX [IX_FK_TestiraPrihvata]
ON [dbo].[Prihvatas]
    ([TestiraPsenicaIdPsenice], [TestiraTestKvalitetaIdTesta]);
GO

-- Creating foreign key on [Mlin_IdMlina] in table 'Silos'
ALTER TABLE [dbo].[Silos]
ADD CONSTRAINT [FK_MlinSilos]
    FOREIGN KEY ([Mlin_IdMlina])
    REFERENCES [dbo].[Mlins]
        ([IdMlina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MlinSilos'
CREATE INDEX [IX_FK_MlinSilos]
ON [dbo].[Silos]
    ([Mlin_IdMlina]);
GO

-- Creating foreign key on [Prihvata_PrijemnikJMBG], [Prihvata_TestiraPsenicaIdPsenice], [Prihvata_TestiraTestKvalitetaIdTesta] in table 'Silos'
ALTER TABLE [dbo].[Silos]
ADD CONSTRAINT [FK_SilosPrihvata]
    FOREIGN KEY ([Prihvata_PrijemnikJMBG], [Prihvata_TestiraPsenicaIdPsenice], [Prihvata_TestiraTestKvalitetaIdTesta])
    REFERENCES [dbo].[Prihvatas]
        ([PrijemnikJMBG], [TestiraPsenicaIdPsenice], [TestiraTestKvalitetaIdTesta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SilosPrihvata'
CREATE INDEX [IX_FK_SilosPrihvata]
ON [dbo].[Silos]
    ([Prihvata_PrijemnikJMBG], [Prihvata_TestiraPsenicaIdPsenice], [Prihvata_TestiraTestKvalitetaIdTesta]);
GO

-- Creating foreign key on [Prekrupac_IdPrekrupaca] in table 'Silos'
ALTER TABLE [dbo].[Silos]
ADD CONSTRAINT [FK_SilosPrekrupac]
    FOREIGN KEY ([Prekrupac_IdPrekrupaca])
    REFERENCES [dbo].[Prekrupacs]
        ([IdPrekrupaca])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SilosPrekrupac'
CREATE INDEX [IX_FK_SilosPrekrupac]
ON [dbo].[Silos]
    ([Prekrupac_IdPrekrupaca]);
GO

-- Creating foreign key on [MlinIdMlina] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [FK_MlinPoseduje]
    FOREIGN KEY ([MlinIdMlina])
    REFERENCES [dbo].[Mlins]
        ([IdMlina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PrekrupacIdPrekrupaca] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [FK_PrekrupacPoseduje]
    FOREIGN KEY ([PrekrupacIdPrekrupaca])
    REFERENCES [dbo].[Prekrupacs]
        ([IdPrekrupaca])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrekrupacPoseduje'
CREATE INDEX [IX_FK_PrekrupacPoseduje]
ON [dbo].[Posedujes]
    ([PrekrupacIdPrekrupaca]);
GO

-- Creating foreign key on [Odrzavateljs_JMBG] in table 'OdrzavateljPoseduje'
ALTER TABLE [dbo].[OdrzavateljPoseduje]
ADD CONSTRAINT [FK_OdrzavateljPoseduje_Odrzavatelj]
    FOREIGN KEY ([Odrzavateljs_JMBG])
    REFERENCES [dbo].[Radniks_Odrzavatelj]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Posedujes_MlinIdMlina], [Posedujes_PrekrupacIdPrekrupaca] in table 'OdrzavateljPoseduje'
ALTER TABLE [dbo].[OdrzavateljPoseduje]
ADD CONSTRAINT [FK_OdrzavateljPoseduje_Poseduje]
    FOREIGN KEY ([Posedujes_MlinIdMlina], [Posedujes_PrekrupacIdPrekrupaca])
    REFERENCES [dbo].[Posedujes]
        ([MlinIdMlina], [PrekrupacIdPrekrupaca])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OdrzavateljPoseduje_Poseduje'
CREATE INDEX [IX_FK_OdrzavateljPoseduje_Poseduje]
ON [dbo].[OdrzavateljPoseduje]
    ([Posedujes_MlinIdMlina], [Posedujes_PrekrupacIdPrekrupaca]);
GO

-- Creating foreign key on [PrekrupacIdPrekrupaca] in table 'Pravis'
ALTER TABLE [dbo].[Pravis]
ADD CONSTRAINT [FK_PrekrupacPravi]
    FOREIGN KEY ([PrekrupacIdPrekrupaca])
    REFERENCES [dbo].[Prekrupacs]
        ([IdPrekrupaca])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BrasnoIdBrasna] in table 'Pravis'
ALTER TABLE [dbo].[Pravis]
ADD CONSTRAINT [FK_BrasnoPravi]
    FOREIGN KEY ([BrasnoIdBrasna])
    REFERENCES [dbo].[Brasnoes]
        ([IdBrasna])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrasnoPravi'
CREATE INDEX [IX_FK_BrasnoPravi]
ON [dbo].[Pravis]
    ([BrasnoIdBrasna]);
GO

-- Creating foreign key on [MagacionerJMBG] in table 'Uzimas'
ALTER TABLE [dbo].[Uzimas]
ADD CONSTRAINT [FK_MagacionerUzima]
    FOREIGN KEY ([MagacionerJMBG])
    REFERENCES [dbo].[Radniks_Magacioner]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PraviPrekrupacIdPrekrupaca], [PraviBrasnoIdBrasna] in table 'Uzimas'
ALTER TABLE [dbo].[Uzimas]
ADD CONSTRAINT [FK_PraviUzima]
    FOREIGN KEY ([PraviPrekrupacIdPrekrupaca], [PraviBrasnoIdBrasna])
    REFERENCES [dbo].[Pravis]
        ([PrekrupacIdPrekrupaca], [BrasnoIdBrasna])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PraviUzima'
CREATE INDEX [IX_FK_PraviUzima]
ON [dbo].[Uzimas]
    ([PraviPrekrupacIdPrekrupaca], [PraviBrasnoIdBrasna]);
GO

-- Creating foreign key on [Uzima_MagacionerJMBG], [Uzima_PraviPrekrupacIdPrekrupaca], [Uzima_PraviBrasnoIdBrasna] in table 'Skladistes'
ALTER TABLE [dbo].[Skladistes]
ADD CONSTRAINT [FK_SkladisteUzima]
    FOREIGN KEY ([Uzima_MagacionerJMBG], [Uzima_PraviPrekrupacIdPrekrupaca], [Uzima_PraviBrasnoIdBrasna])
    REFERENCES [dbo].[Uzimas]
        ([MagacionerJMBG], [PraviPrekrupacIdPrekrupaca], [PraviBrasnoIdBrasna])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SkladisteUzima'
CREATE INDEX [IX_FK_SkladisteUzima]
ON [dbo].[Skladistes]
    ([Uzima_MagacionerJMBG], [Uzima_PraviPrekrupacIdPrekrupaca], [Uzima_PraviBrasnoIdBrasna]);
GO

-- Creating foreign key on [MlinIdMlina] in table 'Imas'
ALTER TABLE [dbo].[Imas]
ADD CONSTRAINT [FK_MlinIma]
    FOREIGN KEY ([MlinIdMlina])
    REFERENCES [dbo].[Mlins]
        ([IdMlina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SkladisteIdSkladista] in table 'Imas'
ALTER TABLE [dbo].[Imas]
ADD CONSTRAINT [FK_SkladisteIma]
    FOREIGN KEY ([SkladisteIdSkladista])
    REFERENCES [dbo].[Skladistes]
        ([IdSkladista])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SkladisteIma'
CREATE INDEX [IX_FK_SkladisteIma]
ON [dbo].[Imas]
    ([SkladisteIdSkladista]);
GO

-- Creating foreign key on [Kamion_IdKamiona] in table 'Imas'
ALTER TABLE [dbo].[Imas]
ADD CONSTRAINT [FK_KamionIma]
    FOREIGN KEY ([Kamion_IdKamiona])
    REFERENCES [dbo].[Kamions]
        ([IdKamiona])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KamionIma'
CREATE INDEX [IX_FK_KamionIma]
ON [dbo].[Imas]
    ([Kamion_IdKamiona]);
GO

-- Creating foreign key on [Prevoznik_JMBG] in table 'Kamions'
ALTER TABLE [dbo].[Kamions]
ADD CONSTRAINT [FK_PrevoznikKamion]
    FOREIGN KEY ([Prevoznik_JMBG])
    REFERENCES [dbo].[Radniks_Prevoznik]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrevoznikKamion'
CREATE INDEX [IX_FK_PrevoznikKamion]
ON [dbo].[Kamions]
    ([Prevoznik_JMBG]);
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Prijemnik'
ALTER TABLE [dbo].[Radniks_Prijemnik]
ADD CONSTRAINT [FK_Prijemnik_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Odrzavatelj'
ALTER TABLE [dbo].[Radniks_Odrzavatelj]
ADD CONSTRAINT [FK_Odrzavatelj_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Magacioner'
ALTER TABLE [dbo].[Radniks_Magacioner]
ADD CONSTRAINT [FK_Magacioner_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Radniks_Prevoznik'
ALTER TABLE [dbo].[Radniks_Prevoznik]
ADD CONSTRAINT [FK_Prevoznik_inherits_Radnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Radniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------