-- Secondary to Reporting

INSERT INTO [LaunchTest_reporting]..CampaignActivityDefinitions
SELECT * FROM [LaunchTest_reporting_secondary]..CampaignActivityDefinitions

INSERT INTO [LaunchTest_reporting]..GoalDefinitions
SELECT * FROM [LaunchTest_reporting_secondary]..GoalDefinitions
 
INSERT INTO [LaunchTest_reporting]..OutcomeDefinitions
SELECT * FROM [LaunchTest_reporting_secondary]..OutcomeDefinitions
 
INSERT INTO [LaunchTest_reporting]..MarketingAssetDefinitions
SELECT * FROM [LaunchTest_reporting_secondary]..MarketingAssetDefinitions

INSERT INTO [LaunchTest_reporting]..Segments
SELECT * FROM [LaunchTest_reporting_secondary]..Segments
 
INSERT INTO [LaunchTest_reporting]..Taxonomy_TaxonEntity
SELECT * FROM [LaunchTest_reporting_secondary]..Taxonomy_TaxonEntity
 
INSERT INTO [LaunchTest_reporting]..Taxonomy_TaxonEntityFieldDefinition
SELECT * FROM [LaunchTest_reporting_secondary]..Taxonomy_TaxonEntityFieldDefinition
 
INSERT INTO [LaunchTest_reporting]..Taxonomy_TaxonEntityFieldValue
SELECT * FROM [LaunchTest_reporting_secondary]..Taxonomy_TaxonEntityFieldValue