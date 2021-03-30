using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class EmployeeDetails
    {
        public EmployeeDetails()
        {
            //Works = JsonConvert.DeserializeObject<Works>(new StreamReader(@"./ClientApp/src/Shared/works.js").ReadToEnd());
            //Employments = JsonConvert.DeserializeObject<Employments>(new StreamReader(@"employment.js").ReadToEnd());
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string OrcId { get; set; }

        public string Password { get; set; }

        public string AccessToken { get; set; }

        public Root Details { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Xml
    {
        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@encoding")]
        public string Encoding { get; set; }

        [JsonProperty("@standalone")]
        public string Standalone { get; set; }
    }

    public class CommonOrcidIdentifier
    {
        [JsonProperty("common:uri")]
        public string CommonUri { get; set; }

        [JsonProperty("common:path")]
        public string CommonPath { get; set; }

        [JsonProperty("common:host")]
        public string CommonHost { get; set; }
    }

    public class PreferencesPreferences
    {
        [JsonProperty("preferences:locale")]
        public string PreferencesLocale { get; set; }
    }

    public class HistoryHistory
    {
        [JsonProperty("history:creation-method")]
        public string HistoryCreationMethod { get; set; }

        [JsonProperty("history:submission-date")]
        public DateTime HistorySubmissionDate { get; set; }

        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("history:claimed")]
        public string HistoryClaimed { get; set; }

        [JsonProperty("history:verified-email")]
        public string HistoryVerifiedEmail { get; set; }

        [JsonProperty("history:verified-primary-email")]
        public string HistoryVerifiedPrimaryEmail { get; set; }
    }

    public class PersonName
    {
        [JsonProperty("@visibility")]
        public string Visibility { get; set; }

        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("common:created-date")]
        public DateTime CommonCreatedDate { get; set; }

        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("personal-details:given-names")]
        public string PersonalDetailsGivenNames { get; set; }

        [JsonProperty("personal-details:family-name")]
        public string PersonalDetailsFamilyName { get; set; }
    }

    public class OtherNameOtherNames
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ResearcherUrlResearcherUrls
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class EmailEmails
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class AddressAddresses
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class KeywordKeywords
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ExternalIdentifierExternalIdentifiers
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class PersonPerson
    {
        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("person:name")]
        public PersonName PersonName { get; set; }

        [JsonProperty("other-name:other-names")]
        public OtherNameOtherNames OtherNameOtherNames { get; set; }

        [JsonProperty("researcher-url:researcher-urls")]
        public ResearcherUrlResearcherUrls ResearcherUrlResearcherUrls { get; set; }

        [JsonProperty("email:emails")]
        public EmailEmails EmailEmails { get; set; }

        [JsonProperty("address:addresses")]
        public AddressAddresses AddressAddresses { get; set; }

        [JsonProperty("keyword:keywords")]
        public KeywordKeywords KeywordKeywords { get; set; }

        [JsonProperty("external-identifier:external-identifiers")]
        public ExternalIdentifierExternalIdentifiers ExternalIdentifierExternalIdentifiers { get; set; }
    }

    public class ActivitiesDistinctions
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ActivitiesEducations
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class CommonSourceOrcid
    {
        [JsonProperty("common:uri")]
        public string CommonUri { get; set; }

        [JsonProperty("common:path")]
        public string CommonPath { get; set; }

        [JsonProperty("common:host")]
        public string CommonHost { get; set; }
    }

    public class CommonSource
    {
        [JsonProperty("common:source-orcid")]
        public CommonSourceOrcid CommonSourceOrcid { get; set; }

        [JsonProperty("common:source-name")]
        public string CommonSourceName { get; set; }
    }

    public class CommonStartDate
    {
        [JsonProperty("common:year")]
        public string CommonYear { get; set; }

        [JsonProperty("common:month")]
        public string CommonMonth { get; set; }

        [JsonProperty("common:day")]
        public string CommonDay { get; set; }
    }

    public class CommonAddress
    {
        [JsonProperty("common:city")]
        public string CommonCity { get; set; }

        [JsonProperty("common:region")]
        public string CommonRegion { get; set; }

        [JsonProperty("common:country")]
        public string CommonCountry { get; set; }
    }

    public class CommonOrganization
    {
        [JsonProperty("common:name")]
        public string CommonName { get; set; }

        [JsonProperty("common:address")]
        public CommonAddress CommonAddress { get; set; }
    }

    public class CommonEndDate
    {
        [JsonProperty("common:year")]
        public string CommonYear { get; set; }

        [JsonProperty("common:month")]
        public string CommonMonth { get; set; }

        [JsonProperty("common:day")]
        public string CommonDay { get; set; }
    }

    public class EmploymentEmploymentSummary
    {
        [JsonProperty("@put-code")]
        public string PutCode { get; set; }

        [JsonProperty("@display-index")]
        public string DisplayIndex { get; set; }

        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("@visibility")]
        public string Visibility { get; set; }

        [JsonProperty("common:created-date")]
        public DateTime CommonCreatedDate { get; set; }

        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("common:source")]
        public CommonSource CommonSource { get; set; }

        [JsonProperty("common:department-name")]
        public string CommonDepartmentName { get; set; }

        [JsonProperty("common:role-title")]
        public string CommonRoleTitle { get; set; }

        [JsonProperty("common:start-date")]
        public CommonStartDate CommonStartDate { get; set; }

        [JsonProperty("common:organization")]
        public CommonOrganization CommonOrganization { get; set; }

        [JsonProperty("common:url")]
        public string CommonUrl { get; set; }

        [JsonProperty("common:end-date")]
        public CommonEndDate CommonEndDate { get; set; }
    }

    public class ActivitiesAffiliationGroup
    {
        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("common:external-ids")]
        public object CommonExternalIds { get; set; }

        [JsonProperty("employment:employment-summary")]
        public EmploymentEmploymentSummary EmploymentEmploymentSummary { get; set; }
    }

    public class ActivitiesEmployments
    {
        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("activities:affiliation-group")]
        public List<ActivitiesAffiliationGroup> ActivitiesAffiliationGroup { get; set; }
    }

    public class ActivitiesFundings
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ActivitiesInvitedPositions
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ActivitiesMemberships
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ActivitiesPeerReviews
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ActivitiesQualifications
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ActivitiesResearchResources
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class ActivitiesServices
    {
        [JsonProperty("@path")]
        public string Path { get; set; }
    }

    public class WorkTitle
    {
        [JsonProperty("common:title")]
        public string CommonTitle { get; set; }
    }

    public class CommonPublicationDate
    {
        [JsonProperty("common:year")]
        public string CommonYear { get; set; }

        [JsonProperty("common:month")]
        public string CommonMonth { get; set; }

        [JsonProperty("common:day")]
        public string CommonDay { get; set; }
    }

    public class WorkWorkSummary
    {
        [JsonProperty("@put-code")]
        public string PutCode { get; set; }

        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("@visibility")]
        public string Visibility { get; set; }

        [JsonProperty("@display-index")]
        public string DisplayIndex { get; set; }

        [JsonProperty("common:created-date")]
        public DateTime CommonCreatedDate { get; set; }

        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("common:source")]
        public CommonSource CommonSource { get; set; }

        [JsonProperty("work:title")]
        public WorkTitle WorkTitle { get; set; }

        [JsonProperty("common:external-ids")]
        public object CommonExternalIds { get; set; }

        [JsonProperty("common:url")]
        public string CommonUrl { get; set; }

        [JsonProperty("work:type")]
        public string WorkType { get; set; }

        [JsonProperty("common:publication-date")]
        public CommonPublicationDate CommonPublicationDate { get; set; }

        [JsonProperty("work:journal-title")]
        public string WorkJournalTitle { get; set; }
    }

    public class ActivitiesGroup
    {
        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("common:external-ids")]
        public object CommonExternalIds { get; set; }

        [JsonProperty("work:work-summary")]
        public WorkWorkSummary WorkWorkSummary { get; set; }
    }

    public class ActivitiesWorks
    {
        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("activities:group")]
        public List<ActivitiesGroup> ActivitiesGroup { get; set; }
    }

    public class ActivitiesActivitiesSummary
    {
        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("common:last-modified-date")]
        public DateTime CommonLastModifiedDate { get; set; }

        [JsonProperty("activities:distinctions")]
        public ActivitiesDistinctions ActivitiesDistinctions { get; set; }

        [JsonProperty("activities:educations")]
        public ActivitiesEducations ActivitiesEducations { get; set; }

        [JsonProperty("activities:employments")]
        public ActivitiesEmployments ActivitiesEmployments { get; set; }

        [JsonProperty("activities:fundings")]
        public ActivitiesFundings ActivitiesFundings { get; set; }

        [JsonProperty("activities:invited-positions")]
        public ActivitiesInvitedPositions ActivitiesInvitedPositions { get; set; }

        [JsonProperty("activities:memberships")]
        public ActivitiesMemberships ActivitiesMemberships { get; set; }

        [JsonProperty("activities:peer-reviews")]
        public ActivitiesPeerReviews ActivitiesPeerReviews { get; set; }

        [JsonProperty("activities:qualifications")]
        public ActivitiesQualifications ActivitiesQualifications { get; set; }

        [JsonProperty("activities:research-resources")]
        public ActivitiesResearchResources ActivitiesResearchResources { get; set; }

        [JsonProperty("activities:services")]
        public ActivitiesServices ActivitiesServices { get; set; }

        [JsonProperty("activities:works")]
        public ActivitiesWorks ActivitiesWorks { get; set; }
    }

    public class RecordRecord
    {
        [JsonProperty("@path")]
        public string Path { get; set; }

        [JsonProperty("@xmlns:internal")]
        public string XmlnsInternal { get; set; }

        [JsonProperty("@xmlns:education")]
        public string XmlnsEducation { get; set; }

        [JsonProperty("@xmlns:distinction")]
        public string XmlnsDistinction { get; set; }

        [JsonProperty("@xmlns:deprecated")]
        public string XmlnsDeprecated { get; set; }

        [JsonProperty("@xmlns:other-name")]
        public string XmlnsOtherName { get; set; }

        [JsonProperty("@xmlns:membership")]
        public string XmlnsMembership { get; set; }

        [JsonProperty("@xmlns:error")]
        public string XmlnsError { get; set; }

        [JsonProperty("@xmlns:common")]
        public string XmlnsCommon { get; set; }

        [JsonProperty("@xmlns:record")]
        public string XmlnsRecord { get; set; }

        [JsonProperty("@xmlns:personal-details")]
        public string XmlnsPersonalDetails { get; set; }

        [JsonProperty("@xmlns:keyword")]
        public string XmlnsKeyword { get; set; }

        [JsonProperty("@xmlns:email")]
        public string XmlnsEmail { get; set; }

        [JsonProperty("@xmlns:external-identifier")]
        public string XmlnsExternalIdentifier { get; set; }

        [JsonProperty("@xmlns:funding")]
        public string XmlnsFunding { get; set; }

        [JsonProperty("@xmlns:preferences")]
        public string XmlnsPreferences { get; set; }

        [JsonProperty("@xmlns:address")]
        public string XmlnsAddress { get; set; }

        [JsonProperty("@xmlns:invited-position")]
        public string XmlnsInvitedPosition { get; set; }

        [JsonProperty("@xmlns:work")]
        public string XmlnsWork { get; set; }

        [JsonProperty("@xmlns:history")]
        public string XmlnsHistory { get; set; }

        [JsonProperty("@xmlns:employment")]
        public string XmlnsEmployment { get; set; }

        [JsonProperty("@xmlns:qualification")]
        public string XmlnsQualification { get; set; }

        [JsonProperty("@xmlns:service")]
        public string XmlnsService { get; set; }

        [JsonProperty("@xmlns:person")]
        public string XmlnsPerson { get; set; }

        [JsonProperty("@xmlns:activities")]
        public string XmlnsActivities { get; set; }

        [JsonProperty("@xmlns:researcher-url")]
        public string XmlnsResearcherUrl { get; set; }

        [JsonProperty("@xmlns:peer-review")]
        public string XmlnsPeerReview { get; set; }

        [JsonProperty("@xmlns:bulk")]
        public string XmlnsBulk { get; set; }

        [JsonProperty("@xmlns:research-resource")]
        public string XmlnsResearchResource { get; set; }

        [JsonProperty("common:orcid-identifier")]
        public CommonOrcidIdentifier CommonOrcidIdentifier { get; set; }

        [JsonProperty("preferences:preferences")]
        public PreferencesPreferences PreferencesPreferences { get; set; }

        [JsonProperty("history:history")]
        public HistoryHistory HistoryHistory { get; set; }

        [JsonProperty("person:person")]
        public PersonPerson PersonPerson { get; set; }

        [JsonProperty("activities:activities-summary")]
        public ActivitiesActivitiesSummary ActivitiesActivitiesSummary { get; set; }
    }

    public class Root
    {
        [JsonProperty("?xml")]
        public Xml Xml { get; set; }

        [JsonProperty("record:record")]
        public RecordRecord RecordRecord { get; set; }
    }


}
