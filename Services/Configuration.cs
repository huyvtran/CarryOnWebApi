using Services.Interfaces;
using System;
using System.Configuration;
using System.Globalization;

namespace Services
{
    /// <summary>
    /// Provide a real configuration based on ConfigurationManager.AppSettings instance
    /// </summary>
    /// <seealso cref="Credemtel.POR.Services.IConfigurationProvider" />
    public class Configuration : IConfigurationProvider
    {
        private const string ConfirmationLetterLayoutKey = "conf:ConfirmationLetterLayout";
        private const string RectificationLetterLayoutKey = "conf:RectificationLetterLayout";
        private const string UndeliveredLetterLayoutKey = "conf:UndeliveredLetterLayout";
        private const string PartialDeliveredLetterLayoutKey = "conf:PartialDeliveredLetterLayout";
        private const string FullDeliveredLetterLayoutKey = "conf:FullDeliveredLetterLayout";
        private const string FullDeliveredLetterNoReturnLayoutKey = "conf:FullDeliveredLetterNoReturnLayout"; 
        private const string ReallocateLetterLayoutKey = "conf:ReallocateLetterLayout"; 
        private const string LogisticLetterLayoutKey = "conf:LogisticLetterLayout";
		private const string LogoPathKey = "conf:LogoPath";
		private const string DocumentFolderKey = "conf:DocumentFolder";
        private const string EnableTracingKey = "conf:EnableTracing";
        private const string EnableApiTracingKey = "conf:EnableApiTracing";
        private const string BasePathKey = "conf:BasePath";
        private const string CredemtelSignatureUrlKey = "conf:CredemtelSignatureUrl";
        private const string N4D_ApplicationCode = "conf:N4D_applicationCode";
        private const string N4D_Password = "conf:N4D_password";
        private const string N4D_MajorVersion = "conf:N4D_majorVersion";
        private const string N4D_MinorVersion = "conf:N4D_minorVersion";
        private const string N4D_OperationTimeout = "conf:N4D_OperationTimeout";
        private static IConfigurationProvider CurrentConfiguration;
        private string path = "";
        private string serverPath = "";

        public Configuration()
        {
            //Avoid new configuration instance
            this.path = ConfigurationManager.AppSettings[BasePathKey].ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        private Configuration(string path, string serverPath)
        {
            this.path = path;
            this.serverPath = serverPath;

        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IConfigurationProvider Current
        {
            get
            {
                var path = ConfigurationManager.AppSettings[BasePathKey].ToString();
                return CurrentConfiguration ?? (CurrentConfiguration = new Configuration(path, null));
            }
        }

        /// <summary>
        /// Instances the current by path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static IConfigurationProvider InstanceCurrentByServerPath(string servePath)
        {
            var path = ConfigurationManager.AppSettings[BasePathKey].ToString();
            return CurrentConfiguration == null ? (CurrentConfiguration = new Configuration(path, servePath)) : CurrentConfiguration.UpdateServerPath(servePath);
        }

        /// <summary>
        /// Update current path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IConfigurationProvider UpdateServerPath(string path)
        {
            this.serverPath = path;
            return CurrentConfiguration;
        }

        /// <summary>
        /// Gets the confirmation letter layout.
        /// </summary>
        /// <value>
        /// The confirmation letter layout.
        /// </value>
        public string ConfirmationLetterLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[ConfirmationLetterLayoutKey].ToString();
            }
        }

        /// <summary>
        /// Gets the rectification letter layout.
        /// </summary>
        /// <value>
        /// The rectification letter layout.
        /// </value>
        public string RectificationLetterLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[RectificationLetterLayoutKey].ToString();
            }
        }

        /// <summary>
        /// Gets the undelivered letter layout.
        /// </summary>
        /// <value>
        /// The undelivered letter layout.
        /// </value>
        public string UndeliveredLetterLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[UndeliveredLetterLayoutKey].ToString();
            }
        }

        /// <summary>
        /// Gets the partial delivered letter layout.
        /// </summary>
        /// <value>
        /// The partial delivered letter layout.
        /// </value>
        public string PartialDeliveredLetterLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[PartialDeliveredLetterLayoutKey].ToString();
            }
        }

        /// <summary>
        /// Gets the full delivered letter layout.
        /// </summary>
        /// <value>
        /// The full delivered letter layout.
        /// </value>
        public string FullDeliveredLetterLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[FullDeliveredLetterLayoutKey].ToString();
            }
        }

        /// <summary>
        /// Gets the full delivered No Return letter layout.
        /// </summary>
        /// <value>
        /// The full delivered letter layout.
        /// </value>
        public string FullDeliveredLetterNoReturnLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[FullDeliveredLetterNoReturnLayoutKey].ToString();
            }
        }

        /// <summary>
        /// Gets the full delivered No Return letter layout.
        /// </summary>
        /// <value>
        /// The full delivered letter layout.
        /// </value>
        public string ReallocateLetterLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[ReallocateLetterLayoutKey].ToString();
            }
        }

        /// <summary>
        /// Gets the logistic letter layout.
        /// </summary>
        /// <value>
        /// The logistic letter layout.
        /// </value>
        public string LogisticLetterLayout
        {
            get
            {
                return serverPath + ConfigurationManager.AppSettings[LogisticLetterLayoutKey].ToString();
            }
        }
        /// <summary>
        /// Gets the document folder.
        /// </summary>
        /// <value>
        /// The document folder.
        /// </value>
        public string DocumentFolder
        {
            get
            {
                return path + ConfigurationManager.AppSettings[DocumentFolderKey].ToString();
            }
        }

        /// <summary>
        /// Get Folder Path by company id and folderId
        /// </summary>
        /// <param name="companyId">company Id.</param>
        /// <param name="folderId">folder Id.</param>
        /// <returns>username</returns>    
        public string GetFolderPath(int companyId, int folderId)
        {
            return System.IO.Path.Combine(DocumentFolder, string.Format("{0}_{1}", companyId, folderId));
        }

        /// <summary>
        /// Gets the document folder.
        /// </summary>
        /// <value>
        /// The document folder.
        /// </value>
        public string CompanyConfigurationPath
        {
            get
            {
                return path;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [enable tracing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable tracing]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableTracing
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings[EnableTracingKey]);
            }
        }
        /// <summary>
        /// Gets a value indicating whether [enable Api tracing].
        /// </summary>
        public bool EnableApiTracing
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings[EnableApiTracingKey]);
            }
        }

        /// <summary>
        /// Get the current ApplicationCode for N4D 
        /// </summary>
        public string N4DApplicationCode
        {
            get
            {
                return ConfigurationManager.AppSettings[N4D_ApplicationCode].ToString();
            }
        }

        /// <summary>
        /// Get the current Password for N4D 
        /// </summary>
        public string N4DPassword
        {
            get
            {
                return ConfigurationManager.AppSettings[N4D_Password].ToString();
            }
        }
        /// <summary>
        /// Get the current Major version for N4D 
        /// </summary>
        public int N4DMajorVersion
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings[N4D_MajorVersion].ToString());
            }
        }
        /// <summary>
        /// Get the current Minor version for N4D 
        /// </summary>
        public int N4DMinorVersion
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings[N4D_MinorVersion].ToString());
            }
        }
        /// <summary>
        /// Get Net4Delivering operation timeout
        /// </summary>
        public TimeSpan N4DOperationTimeout
        {
            get
            {
                DateTime dt;
                if (!DateTime.TryParseExact(ConfigurationManager.AppSettings[N4D_OperationTimeout].ToString(),
                    "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    // default returns 10 minutes
                    return new TimeSpan(0, 10, 0);
                }
                return dt.TimeOfDay;                
            }
        }
        /// <summary>
        /// Get username for N4D from ApplicationCode and CompanyCode
        /// </summary>
        /// <param name="applicationCode">application code</param>
        /// <param name="companyCode">company code</param>
        /// <returns>username</returns>
        public string GetN4DUsername(string applicationCode, string companyCode)
        {
            return string.Format("{0}_{1}", applicationCode, companyCode);
        }

		public string LogoPath
		{
			get
			{
				return serverPath + ConfigurationManager.AppSettings[LogoPathKey].ToString();
			}
		}

        /// <summary>
        /// Gets credemtel signature URL.
        /// </summary>
        /// <value>
        /// Credemtel Signature URL.
        /// </value>
        public string CredemtelSignatureUrl
        {
            get
            {
                return ConfigurationManager.AppSettings[CredemtelSignatureUrlKey].ToString();
            }
        }
    }
}
