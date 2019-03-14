-- Reporting to Secondary

INSERT INTO [LaunchTest_reporting_secondary]..CampaignActivityDefinitions
SELECT * FROM [LaunchTest_reporting]..CampaignActivityDefinitions

INSERT INTO [LaunchTest_reporting_secondary]..GoalDefinitions
SELECT * FROM [LaunchTest_reporting]..GoalDefinitions
 
INSERT INTO [LaunchTest_reporting_secondary]..OutcomeDefinitions
SELECT * FROM [LaunchTest_reporting]..OutcomeDefinitions
 
INSERT INTO [LaunchTest_reporting_secondary]..MarketingAssetDefinitions
SELECT * FROM [LaunchTest_reporting]..MarketingAssetDefinitions

INSERT INTO [LaunchTest_reporting_secondary]..Segments
SELECT * FROM [LaunchTest_reporting]..Segments
 
INSERT INTO [LaunchTest_reporting_secondary]..Taxonomy_TaxonEntity
SELECT * FROM [LaunchTest_reporting]..Taxonomy_TaxonEntity
 
INSERT INTO [LaunchTest_reporting_secondary]..Taxonomy_TaxonEntityFieldDefinition
SELECT * FROM [LaunchTest_reporting]..Taxonomy_TaxonEntityFieldDefinition
 
INSERT INTO [LaunchTest_reporting_secondary]..Taxonomy_TaxonEntityFieldValue
SELECT * FROM [LaunchTest_reporting]..Taxonomy_TaxonEntityFieldValue