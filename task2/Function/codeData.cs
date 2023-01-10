using System;
using System.Collections.Generic;
using System.Text;

namespace Function
{
	public class codeData
	{

		static String separator = ",";

		//localFirstName"
		public String localFirstName;

		//localLastName"
		public String localLastName;

		//romanizedFirstName
		public string romanizedFirstName;

		//romanizedLastName
		public string romanizedLastName;

		// telephone"
		public String phoneNumber;

		// socialChannel"
		public String socialChannel;

		// socialMasterId"
		public String socialMasterId;

		// socialId"
		public String socialId;

		// CBDT"
		public Boolean CBDT = false;

		public string CBDTDate;
		public string RomanizedValidated;
		public static QrcodeData fromCsv(String decoded)
		{
			QrcodeData output = new QrcodeData();
			String[] a = decoded.Split(separator);
			if (a.Length < 6)
				throw new ArgumentOutOfRangeException("missing fields in decoded string, found " + a.Length);
			output.localFirstName = (a[0]);
			output.localLastName = (a[1]);
			output.romanizedFirstName = (a[0]);
			output.romanizedLastName = (a[1]);
			output.RomanizedValidated = "";
			output.CBDTDate = "";
			output.phoneNumber = (a[2]);
			output.socialChannel = (a[3]);
			output.socialMasterId = (a[4]);
			output.socialId = (a[5]);
			if (a.Length == 7)
				output.CBDT = (Boolean.Parse(a[6]));
			return output;
		}
	}
}
