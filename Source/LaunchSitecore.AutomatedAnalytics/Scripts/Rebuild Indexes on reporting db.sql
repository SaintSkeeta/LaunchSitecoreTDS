ALTER INDEX PK__Contacts__5C66259B628FA481   ON Contacts     REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_CampaignActivityDefinitions            ON CampaignActivityDefinitions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_DimensionKeys            ON DimensionKeys           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Fact_Conversions   ON Fact_Conversions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Conversion_SiteName   ON Fact_Conversions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Conversion_Goal   ON Fact_Conversions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Conversion_Language   ON Fact_Conversions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Conversion_Campaign   ON Fact_Conversions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Conversion_DeviceName   ON Fact_Conversions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Conversion_TrafficType   ON Fact_Conversions           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX IX_Fact_SegmentMetrics_All_Columns  ON Fact_SegmentMetrics   REBUILD WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Fact_Failures   ON Fact_Failures           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Failures_FailureDetails   ON Fact_Failures           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Failures_PageEventDefinition   ON Fact_Failures           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Failures_Keywords   ON Fact_Failures           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Failures_ReferringSite   ON Fact_Failures           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_FormEvents   ON Fact_FormEvents           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_FormStatisticsByContact   ON Fact_FormStatisticsByContact           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_FormSummary   ON Fact_FormSummary           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_ByFieldValueId   ON Fact_FormSummary           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX IX_Fact_PageViews_Contact       ON Fact_PageViews             REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_PageViews_Item       ON Fact_PageViews             REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX PK_PageViews          ON Fact_PageViews         REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)


ALTER INDEX PK_Fact_PageViewsByLanguage   ON Fact_PageViewsByLanguage           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Fact_RulesExposure           ON Fact_RulesExposure       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Fact_Metrics           ON Fact_SegmentMetrics       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_SegmentMetrics_All_Columns ON Fact_SegmentMetrics       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_SlowPages            ON Fact_SlowPages           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_SlowPages_Visit            ON Fact_SlowPages           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_SlowPages_Account            ON Fact_SlowPages           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_SlowPages_Item            ON Fact_SlowPages           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_SlowPages_Duration            ON Fact_SlowPages           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_SlowPages_Contact            ON Fact_SlowPages           REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX IX_ByDate ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_Campaign ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_ByDateAndTrafficType ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_Item ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_ReferringSite ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_DeviceName ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_Keywords ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_Language ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_TrafficType ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Traffic_SiteName ON Fact_Traffic REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Fact_ValueBySource     ON Fact_ValueBySource      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_ValueBySource_DeviceName     ON Fact_ValueBySource      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_ValueBySource_Language     ON Fact_ValueBySource      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_ValueBySource_SiteName     ON Fact_ValueBySource      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_ValueBySource_TrafficType     ON Fact_ValueBySource      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Fact_Visits     ON Fact_Visits      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Visits_FirstVisit     ON Fact_Visits      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Visits_Contact     ON Fact_Visits      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Visits_Language     ON Fact_Visits      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_Visits_Item	     ON Fact_Visits      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Fact_VisitsByBusinessContactLocation     ON Fact_VisitsByBusinessContactLocation      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_VisitsByBusinessContactLocation_SiteName     ON Fact_VisitsByBusinessContactLocation      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_VisitsByBusinessContactLocation_Account     ON Fact_VisitsByBusinessContactLocation      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_VisitsByBusinessContactLocation_Language     ON Fact_VisitsByBusinessContactLocation      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_VisitsByBusinessContactLocation_DeviceName     ON Fact_VisitsByBusinessContactLocation      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_VisitsByBusinessContactLocation_TrafficType     ON Fact_VisitsByBusinessContactLocation      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Fact_VisitsByBusinessContactLocation_Contact     ON Fact_VisitsByBusinessContactLocation      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK__FailureD__34FAE29417036CC0     ON FailureDetails      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_FormFieldValues     ON FormFieldValues      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_GoalDefinitions     ON GoalDefinitions      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_ReferringSites ON ReferringSites       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Keywords ON Keywords       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Items ON Items       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_OutcomeDefinitions     ON OutcomeDefinitions      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_PageEventDefinitions     ON PageEventDefinitions      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Goals     ON PageEventDefinitions      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Segments   ON Segments         REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX IX_SegmentRecords_All_Columns2   ON SegmentRecords         REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_SegmentRecords_All_Columns      ON SegmentRecords       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX PK_Fact_SegmentRecords_1      ON SegmentRecords       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Trail_Interactions          ON Trail_Interactions      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Trail_Interactions_Processed          ON Trail_Interactions      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)

ALTER INDEX PK_Trees ON Trees       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Trees ON Trees       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)
ALTER INDEX IX_Trees_Visits ON Trees       REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)


ALTER INDEX PK_Trail_PathAnalyzer          ON Trail_PathAnalyzer      REBUILD  WITH (ONLINE = ON, FILLFACTOR = 85)


SELECT OBJECT_NAME(ind.OBJECT_ID) AS TableName, 
   ind.name AS IndexName, indexstats.index_type_desc AS IndexType, 
   indexstats.avg_fragmentation_in_percent,indexstats.page_count 
 FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) indexstats 
   INNER JOIN sys.indexes ind ON ind.object_id = indexstats.object_id 
        AND ind.index_id = indexstats.index_id 
  WHERE 
-- indexstats.avg_fragmentation_in_percent , e.g. >30, you can specify any number in percent 
   indexstats.avg_fragmentation_in_percent > 30
--ind.name = 'IX_Fact_Traffic_Keywords'
  AND ind.Name is not null 
  --ORDER BY indexstats.avg_fragmentation_in_percent DESC
  ORDER BY TableName


