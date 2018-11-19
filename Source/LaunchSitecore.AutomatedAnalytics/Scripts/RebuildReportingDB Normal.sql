-- Reporting to Secondary

INSERT INTO [dhrdummy_reporting_secondary]..CampaignActivityDefinitions
SELECT * FROM [dhrdummy_reporting]..CampaignActivityDefinitions

INSERT INTO [dhrdummy_reporting_secondary]..GoalDefinitions
SELECT * FROM [dhrdummy_reporting]..GoalDefinitions
 
INSERT INTO [dhrdummy_reporting_secondary]..OutcomeDefinitions
SELECT * FROM [dhrdummy_reporting]..OutcomeDefinitions
 
INSERT INTO [dhrdummy_reporting_secondary]..MarketingAssetDefinitions
SELECT * FROM [dhrdummy_reporting]..MarketingAssetDefinitions

INSERT INTO [dhrdummy_reporting_secondary]..Segments
SELECT * FROM [dhrdummy_reporting]..Segments
 
INSERT INTO [dhrdummy_reporting_secondary]..Taxonomy_TaxonEntity
SELECT * FROM [dhrdummy_reporting]..Taxonomy_TaxonEntity
 
INSERT INTO [dhrdummy_reporting_secondary]..Taxonomy_TaxonEntityFieldDefinition
SELECT * FROM [dhrdummy_reporting]..Taxonomy_TaxonEntityFieldDefinition
 
INSERT INTO [dhrdummy_reporting_secondary]..Taxonomy_TaxonEntityFieldValue
SELECT * FROM [dhrdummy_reporting]..Taxonomy_TaxonEntityFieldValue