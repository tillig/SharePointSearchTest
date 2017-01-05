using System;

namespace SearchTest {
	/// <summary>
	/// Provides the search business logic for the search test application.
	/// </summary>
	public class SearchLogic {
		
		#region Constants
		
		/// <summary>
		/// The types of queries that can be performed.
		/// </summary>
		public enum QueryType{
			/// <summary>
			/// Keyword search - query should be a set of keywords
			/// </summary>
			Keyword,

			/// <summary>
			/// SQL Fulltext search - query should be in SQL Fulltext query syntax
			/// </summary>
			SQLFulltext
		}

		
		/// <summary>
		/// The types of content that can be returned.
		/// </summary>
		[FlagsAttribute]
		public enum ContentType : byte{
			/// <summary>
			/// Content
			/// </summary>
			Content = 1,

			/// <summary>
			/// Document
			/// </summary>
			Document = 2,

			/// <summary>
			/// Form
			/// </summary>
			Form = 4
		}

		#endregion


		#region Variables

		/// <summary>
		/// Query Service provider
		/// </summary>
		private SPSQueryService.QueryService querySvc = null;

		/// <summary>
		/// The query string (no packet wrapper)
		/// </summary>
		private string queryText = "";

		/// <summary>
		/// The query packet
		/// </summary>
		private Microsoft.Search.Query.QueryPacket queryPacket = null;

		/// <summary>
		/// The registration packet
		/// </summary>
		private Microsoft.Search.Registration.Request.RegistrationRequest registrationPacket = null;

		#endregion


		#region Constructors

		/// <summary>
		/// Creates a default SearchLogic object.
		/// </summary>
		public SearchLogic(){
			// Create a new query service object
			querySvc = new SPSQueryService.QueryService();

			// Build default new registration packet
			registrationPacket = new Microsoft.Search.Registration.Request.RegistrationRequest();
			registrationPacket.revision = 1;
			registrationPacket.revisionSpecified = true;
		}

		#endregion


		#region Properties

		/// <summary>
		/// Gets the current query service object.
		/// </summary>
		public SPSQueryService.QueryService QueryService{
			get{
				return querySvc;
			}
		}

		
		/// <summary>
		/// Gets the current query text (no packet wrapper).
		/// </summary>
		public string QueryText{
			get{
				return queryText;
			}
		}

		
		/// <summary>
		/// Gets the current query packet (query text and wrapper).
		/// </summary>
		public Microsoft.Search.Query.QueryPacket QueryPacket{
			get{
				return queryPacket;
			}
		}

		
		/// <summary>
		/// Gets the current registration packet.
		/// </summary>
		public Microsoft.Search.Registration.Request.RegistrationRequest RegistrationPacket{
			get{
				return registrationPacket;
			}
		}

		#endregion


		#region Public Methods

		/// <summary>
		/// Registers the query service with the search provider.
		/// </summary>
		/// <returns>The results of registration.</returns>
		public string Registration(){
			return querySvc.Registration(Helper.SerializeToString(registrationPacket));
		}

		
		/// <summary>
		/// Sets the search query and builds the query packet.
		/// </summary>
		/// <param name="query">The text to query for.</param>
		/// <param name="queryType">The type of query to execute.</param>
		/// <param name="startAt">The first record in the set to return.</param>
		/// <param name="count">The total number of records to return.</param>
		/// <param name="contentTypes">The content types that should be returned; a combination of <see cref="ContentType"/> flags</param>
		public void SetQuery(string query, QueryType queryType, uint startAt, uint count, byte contentTypes){
			// Set up the new query packet
			queryPacket = new Microsoft.Search.Query.QueryPacket();
			queryPacket.revision = 1000;
			queryPacket.revisionSpecified = true;
			
			// Set up the query
			Microsoft.Search.Query.QueryType qtype = new Microsoft.Search.Query.QueryType();
			qtype.domain = "QDomain";

			// Set up the supported formats
			qtype.SupportedFormats = new Microsoft.Search.Query.SupportedFormatsType();
			int numTypesToGet = 0;
			Array contentTypeValues = Enum.GetValues(typeof(SearchLogic.ContentType));
			for(int i = 0; i < contentTypeValues.Length; i++){
				byte currentValue = (byte)contentTypeValues.GetValue(i);
				if((contentTypes & currentValue) == currentValue){
					numTypesToGet++;
				}
			}
			qtype.SupportedFormats.Format = new Microsoft.Search.Query.FormatType[numTypesToGet];
			int contentTypeCounter = 0;
			for(int i = 0; i < contentTypeValues.Length; i++){
				byte currentValue = (byte)contentTypeValues.GetValue(i);
				if((contentTypes & currentValue) == currentValue){
					qtype.SupportedFormats.Format[contentTypeCounter] = new Microsoft.Search.Query.FormatType();
					qtype.SupportedFormats.Format[contentTypeCounter].revision = 1;
					qtype.SupportedFormats.Format[contentTypeCounter].revisionSpecified = true;
					qtype.SupportedFormats.Format[contentTypeCounter].Value = String.Format("urn:Microsoft.Search.Response.{0}:{0}", (SearchLogic.ContentType)currentValue);
					contentTypeCounter++;
				}
			}

			// Set up the context
			qtype.Context = new Microsoft.Search.Query.ContextType();
			qtype.Context.QueryText = new Microsoft.Search.Query.QueryTextType();
			qtype.Context.QueryText.language = "en-US";
			switch(queryType){
				case QueryType.Keyword:
					qtype.Context.QueryText.type = Microsoft.Search.Query.QueryTextTypeType.STRING;
					break;
				case QueryType.SQLFulltext:
					qtype.Context.QueryText.type = Microsoft.Search.Query.QueryTextTypeType.MSSQLFT;
					break;
				default:
					ResetQuery();
					throw new ArgumentException("Unhandled query type: " + queryType.ToString(), "queryType");
			}

			// Set the query text property
			queryText = query;
			qtype.Context.QueryText.Value = query;

			// Set up the range
			qtype.Range = new Microsoft.Search.Query.RangeType[1];
			qtype.Range[0] = new Microsoft.Search.Query.RangeType();
			qtype.Range[0].Count = count;
			qtype.Range[0].CountSpecified = true;
			qtype.Range[0].StartAt = startAt;

			// Add the query to the packet;
			queryPacket.Query = new Microsoft.Search.Query.QueryType[1];
			queryPacket.Query[0] = qtype;
		}

		
		/// <summary>
		/// Clears the current query and query packet.
		/// </summary>
		public void ResetQuery(){
			queryText = "";
			queryPacket = null;
		}


		/// <summary>
		/// Executes the currently set query.
		/// </summary>
		/// <returns>A string containing the XML query results.</returns>
		public string ExecuteQuery(){
			if(queryPacket == null){
				throw new InvalidOperationException("You must set the current query using SetQuery() before calling ExecuteQuery().", null);
			}

			return querySvc.Query(Helper.SerializeToString(queryPacket));
		}

		#endregion

	}
}
