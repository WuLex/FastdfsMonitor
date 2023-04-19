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
        /// 文件总追加次数
        /// </summary>
        public long TotalAppendCount { get; set; }

        /// <summary>
        ///文件追加成功次数
        /// </summary>
        public long SuccessAppendCount { get; set; }

        /// <summary>
        ///文件总修改次数
        /// </summary>
        public long TotalModifyCount { get; set; }

        /// <summary>
        ///文件修改成功次数
        /// </summary>
        public long SuccessModifyCount { get; set; }

        /// <summary>
        ///文件总截取次数
        /// </summary>
        public long TotalTruncateCount { get; set; }

        /// <summary>
        ///文件截取成功次数
        /// </summary>
        public long SuccessTruncateCount { get; set; }

        /// <summary>
        ///文件总设置元数据次数
        /// </summary>
        public long TotalSetMetaCount { get; set; }

        /// <summary>
        /// 文件设置元数据成功次数
        /// </summary>
        public long SuccessSetMetaCount { get; set; }

        /// <summary>
        ///文件总删除次数
        /// </summary>
        public long TotalDeleteCount { get; set; }

        /// <summary>
        ///文件删除成功次数
        /// </summary>
        public long SuccessDeleteCount { get; set; }


        /// <summary>
        ///文件总下载次数
        /// </summary>
        public long TotalDownloadCount { get; set; }


        /// <summary>
        ///文件下载成功次数
        /// </summary>
        public long SuccessDownloadCount { get; set; }


        /// <summary>
        ///获取文件元数据总次数
        /// </summary>
        public long TotalGetMetaDataCount { get; set; }


        /// <summary>
        ///获取文件元数据成功次数
        /// </summary>
        public long SuccessGetMetaDataCount { get; set; }


        /// <summary>
        ///文件打包成功次数
        /// </summary>
        public long TotalFilePkgCount { get; set; }


        /// <summary>
        /// 文件打包成功次数
        /// </summary>
        public long SuccessFilePkgCount { get; set; } 
        
        
        
        /// <summary>

                                                      ///
                                                      /// </summary>
        public long TotalInSyncCount { get; set; }


        /// <summary>
        ///文件总同步到其他存储服务器次数
        /// </summary>
        public long SuccessInSyncCount { get; set; }


        /// <summary>
        ///文件总从其他存储服务器同步次数
        /// </summary>
        public long TotalOutSyncCount { get; set; }


        /// <summary>
        ///文件成功从其他存储服务器同步次数
        /// </summary>
        public long SuccessOutSyncCount { get; set; }


        /// <summary>
        ///文件总使用Append方式写入次数
        /// </summary>
        public long TotalAppenderCount { get; set; }


        /// <summary>
        ///文件成功使用Append方式写入次数
        /// </summary>
        public long SuccessAppenderCount { get; set; }


        /// <summary>
        ///文件总Flush次数
        /// </summary>
        public long TotalFlushCount { get; set; }


        /// <summary>
        ///文件成功Flush次数
        /// </summary>
        public long SuccessFlushCount { get; set; }


        /// <summary>
        ///文件总字节数
        /// </summary>
        public long TotalUploadBytes { get; set; } 
        
        
        /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessUploadBytes { get; set; } 
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalAppendBytes { get; set; } 
        
        
        /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessAppendBytes { get; set; } 
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalModifyBytes { get; set; }
        
        
        
        /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessModifyBytes { get; set; } 
        
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalDownloadBytes { get; set; } 
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessDownloadBytes { get; set; } 
        
        
        /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalSyncInBytes { get; set; } 
        
        
        /// <summary>

                                                   ///
                                                   /// </summary>
        public long SuccessSyncInBytes { get; set; }
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long TotalSyncOutBytes { get; set; } 
        
        
        
        /// <summary>

                                                    ///
                                                    /// </summary>
        public long SuccessSyncOutBytes { get; set; } 
        
        
        
        /// <summary>

                                                      ///
                                                      /// </summary>
        public long TotalFileOpenCount { get; set; } 
        
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessFileOpenCount { get; set; } 
        
        
        /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFileReadCount { get; set; } 
        
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessFileReadCount { get; set; } 
        
        
        /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFileWriteCount { get; set; } 
        
        
        
        /// <summary>

                                                      ///
                                                      /// </summary>
        public long SuccessFileWriteCount { get; set; } 
        
        
        
        /// <summary>

                                                        ///
                                                        /// </summary>
        public long TotalFileCloseCount { get; set; } 
        
        
        
        /// <summary>

                                                      ///
                                                      /// </summary>
        public long SuccessFileCloseCount { get; set; } 
        
        
        /// <summary>

                                                        ///
                                                        /// </summary>
        public long TotalFileUnlinkCount { get; set; }
        
        
        /// <summary>

                                                       ///
                                                       /// </summary>
        public long SuccessFileUnlinkCount { get; set; } 
        
        
        /// <summary>

                                                         ///
                                                         /// </summary>
        public long TotalFileStatCount { get; set; } 
        
        
        
        /// <summary>

                                                     ///
                                                     /// </summary>
        public long SuccessFileStatCount { get; set; } 
        
        
        /// <summary>

                                                       ///
                                                       /// </summary>
        public long TotalFileListCount { get; set; }



        /// <summary>
        ///获取文件列表成功次数
        /// </summary>
        public long SuccessFileListCount { get; set; }


        /// <summary>
        ///总内部同步文件次数
        /// </summary>
        public long TotalFileSyncInCount { get; set; } 
        
         
    }
}