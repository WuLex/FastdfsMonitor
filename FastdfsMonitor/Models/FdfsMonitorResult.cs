namespace FastdfsMonitor.Models
{
    public class FdfsMonitorResult
    {
        /// <summary>
        /// Tracker服务器数量
        /// </summary>
        public int TrackerCount { get; set; }

        /// <summary>
        /// 存储服务器数量
        /// </summary>
        public int StorageCount { get; set; }

        /// <summary>
        ///活跃存储服务器数量
        /// </summary>
        public int ActiveCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int CurrentWriteServer { get; set; }

        /// <summary>
        ///当前写入的存储服务器编号
        /// </summary>
        public int StorePathCount { get; set; }

        /// <summary>
        /// 存储路径数量
        /// </summary>
        public int SubdirCountPerPath { get; set; }

        /// <summary>
        ///当前可用的Trunk文件ID
        /// </summary>
        public int CurrentTrunkFileId { get; set; }

        /// <summary>
        /// 文件上传成功次数
        /// </summary>
        /// public long TotalUploadCount { get; set; }
        public long SuccessUploadCount { get; set; }

        /// <summary>

        ///文件总上传次数
        /// </summary>
        public long TotalAppendCount { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessAppendCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalModifyCount { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessModifyCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalTruncateCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessTruncateCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalSetMetaCount { get; set; } /// <summary>

                                                    ///
                                                    /// </summary>
        public long SuccessSetMetaCount { get; set; } /// <summary>

                                                      ///
                                                      /// </summary>
        public long TotalDeleteCount { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessDeleteCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalDownloadCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessDownloadCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalGetMetaDataCount { get; set; } /// <summary>

                                                        ///
                                                        /// </summary>
        public long SuccessGetMetaDataCount { get; set; } /// <summary>

                                                          ///
                                                          /// </summary>
        public long TotalFilePkgCount { get; set; } /// <summary>

                                                    ///
                                                    /// </summary>
        public long SuccessFilePkgCount { get; set; } /// <summary>

                                                      ///
                                                      /// </summary>
        public long TotalInSyncCount { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessInSyncCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalOutSyncCount { get; set; } /// <summary>

                                                    ///
                                                    /// </summary>
        public long SuccessOutSyncCount { get; set; } /// <summary>

                                                      ///
                                                      /// </summary>
        public long TotalAppenderCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessAppenderCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFlushCount { get; set; } /// <summary>

                                                  ///
                                                  /// </summary>
        public long SuccessFlushCount { get; set; } /// <summary>

                                                    ///
                                                    /// </summary>
        public long TotalUploadBytes { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessUploadBytes { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalAppendBytes { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessAppendBytes { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalModifyBytes { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessModifyBytes { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalDownloadBytes { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessDownloadBytes { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalSyncInBytes { get; set; } /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessSyncInBytes { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalSyncOutBytes { get; set; } /// <summary>

                                                    ///
                                                    /// </summary>
        public long SuccessSyncOutBytes { get; set; } /// <summary>

                                                      ///
                                                      /// </summary>
        public long TotalFileOpenCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessFileOpenCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFileReadCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessFileReadCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFileWriteCount { get; set; } /// <summary>

                                                      ///
                                                      /// </summary>
        public long SuccessFileWriteCount { get; set; } /// <summary>

                                                        ///
                                                        /// </summary>
        public long TotalFileCloseCount { get; set; } /// <summary>

                                                      ///
                                                      /// </summary>
        public long SuccessFileCloseCount { get; set; } /// <summary>

                                                        ///
                                                        /// </summary>
        public long TotalFileUnlinkCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long SuccessFileUnlinkCount { get; set; } /// <summary>

                                                         ///
                                                         /// </summary>
        public long TotalFileStatCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessFileStatCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFileListCount { get; set; } /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessFileListCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFileSyncInCount { get; set; } /// <summary>

                                                       ///
                                                       /// </summary>
    }
}