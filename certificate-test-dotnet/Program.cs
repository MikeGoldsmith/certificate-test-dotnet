using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Couchbase;
using Couchbase.Authentication.X509;
using Couchbase.Configuration.Client;
using Microsoft.Extensions.Configuration;

namespace certificate_test_dotnet
{
	public static class Program
	{
		public static void Main()
		{
			try
			{
				var properties = new ConfigurationBuilder()
					.AddJsonFile("config.json", optional: false)
					.Build();

				var config = new ClientConfiguration
				{
					Servers = new List<Uri> {new Uri(properties["cluster"])},
					UseSsl = true,
					EnableCertificateAuthentication = true,
					CertificateFactory = CertificateFactory.GetCertificatesFromStore(new CertificateStoreOptions
					{
						StoreLocation = StoreLocation.LocalMachine,
						StoreName = StoreName.Root,
						X509FindType = X509FindType.FindByThumbprint,
						FindValue = properties["cert_thumbprint"]
					})
				};

				var cluster = new Cluster(config);
				var bucket = cluster.OpenBucket(properties["bucket"]);
				var result = bucket.Get<dynamic>(properties["doc_id"]);

				Console.WriteLine($"Found: {result.Value}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
