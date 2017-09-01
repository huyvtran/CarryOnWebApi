
using Entities;
using System;

namespace Services.Interfaces
{
    /// <summary>Interface that provide configuration member</summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        ///  Get or set user info
        /// </summary>
        UserModel UserInfo { get; set; }

        /// <summary>
        /// Gets the document folder.
        /// </summary>
        /// <value>
        /// The document folder.
        /// </value>
        string DocumentFolder { get; }
        /// <summary>
        /// Get Folder Path by company id and folderId
        /// </summary>
        /// <param name="companyId">company Id.</param>
        /// <param name="folderId">folder Id.</param>
        /// <returns>username</returns>   
        string GetFolderPath(int companyId, int folderId);
        /// <summary>
        /// Gets the confirmation letter layout.
        /// </summary>
        /// <value>
        /// The confirmation letter layout.
        /// </value>
        string ConfirmationLetterLayout { get; }

        /// <summary>
        /// Gets the rectification letter layout.
        /// </summary>
        /// <value>
        /// The rectification letter layout.
        /// </value>
        string RectificationLetterLayout { get; } 
        /// <summary>
        /// Gets the undelivered letter layout.
        /// </summary>
        /// <value>
        /// The undelivered letter layout.
        /// </value>
        string UndeliveredLetterLayout { get; }
        /// <summary>
        /// Gets the partial delivered letter layout.
        /// </summary>
        /// <value>
        /// The partial delivered letter layout.
        /// </value>
        string PartialDeliveredLetterLayout { get; }
        /// <summary>
        /// Gets the full delivered letter layout.
        /// </summary>
        /// <value>
        /// The full delivered letter layout.
        /// </value>
        string FullDeliveredLetterLayout { get; }
        /// <summary>
        /// Gets the full delivered no return letter layout.
        /// </summary>
        /// <value>
        /// The full delivered no return letter layout.
        /// </value>
        string FullDeliveredLetterNoReturnLayout { get; }

        /// <summary>
        /// Gets the reallocate letter layout.
        /// </summary>
        /// <value>
        /// The reallocate letter layout.
        /// </value>
        string ReallocateLetterLayout { get; }

        /// <summary>
        /// Gets the logistic letter layout.
        /// </summary>
        /// <value>
        /// The logistic letter layout.
        /// </value>
        string LogisticLetterLayout { get; }


        /// <summary>
        /// Gets a value indicating whether [enable tracing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable tracing]; otherwise, <c>false</c>.
        /// </value>
        bool EnableTracing { get;  }

        /// <summary>
        /// Gets a value indicating whether [enable api tracing].
        /// </summary>
        bool EnableApiTracing { get;  }

        /// <summary>
        /// Update ServerPath
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IConfigurationProvider UpdateServerPath(string path);
        
        /// Get the current ApplicationCode for N4D 
        /// </summary>
        string N4DApplicationCode { get; }
        
        /// <summary>
        /// Get the current Password for N4D 
        /// </summary>
        string N4DPassword { get; }
        /// <summary>
        /// Get the current Major version for N4D 
        /// </summary>
        int N4DMajorVersion { get; }
        /// <summary>
        /// Get the current Minor version for N4D 
        /// </summary>
        int N4DMinorVersion { get; }
        /// <summary>
        /// Get Net4Delivering operation timeout
        /// </summary>
        TimeSpan N4DOperationTimeout { get; }
        /// <summary>
        /// Get username for N4D from ApplicationCode and CompanyCode
        /// </summary>
        /// <param name="applicationCode">application code</param>
        /// <param name="companyCode">company code</param>
        /// <returns>username</returns>
        string GetN4DUsername(string applicationCode, string companyCode);


        /// <summary>
        /// Gets or sets the company configuration path.
        /// </summary>
        /// <value>
        /// The company configuration path.
        /// </value>
        string CompanyConfigurationPath { get; }
		/// <summary>
		/// Path of company logos
		/// </summary>
		string LogoPath { get; }

        string CredemtelSignatureUrl { get; }

    }
}
