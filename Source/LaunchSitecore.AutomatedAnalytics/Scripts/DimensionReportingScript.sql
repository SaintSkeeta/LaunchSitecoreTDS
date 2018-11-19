/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [SegmentRecords].SegmentRecordId,
      [DimensionKeys].DimensionKey
       ,[SegmentRecords].Date
      ,[Visits]
      ,[Pageviews]
      ,[Value]
      ,[Bounces]
      ,[Conversions]
      ,[TimeOnSite]
      ,[Count]
  FROM [SegmentRecords]
  INNER JOIN [DimensionKeys] ON [SegmentRecords].DimensionKeyId = [DimensionKeys].DimensionKeyId
  INNER JOIN [Fact_SegmentMetrics] ON [Fact_SegmentMetrics].SegmentRecordId = [SegmentRecords].SegmentRecordId
  WHERE DimensionKey LIKE 'f59e79e1-5dcc-4c5f-a14c-9673770579c0%'
  ORDER BY Date Desc