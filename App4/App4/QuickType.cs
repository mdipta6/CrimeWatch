using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Crime
    {
        [JsonProperty("cmplnt_num")]
        public string CmplntNum { get; set; }

        [JsonProperty("law_cat_cd")]
        public LawCatCd LawCatCd { get; set; }

        [JsonProperty("cmplnt_fr_dt")]
        public DateTimeOffset CmplntFrDt { get; set; }

        [JsonProperty("ofns_desc")]
        public OfnsDesc OfnsDesc { get; set; }

        [JsonProperty("prem_typ_desc")]
        public string PremTypDesc { get; set; }

        [JsonProperty("ky_cd")]
        public string KyCd { get; set; }

        [JsonProperty("cmplnt_fr_tm")]
        public DateTimeOffset CmplntFrTm { get; set; }

        [JsonProperty("rpt_dt")]
        public DateTimeOffset RptDt { get; set; }

        [JsonProperty("boro_nm")]
        public BoroNm BoroNm { get; set; }

        [JsonProperty("pd_desc")]
        public string PdDesc { get; set; }

        [JsonProperty("pd_cd")]
        public string PdCd { get; set; }

        [JsonProperty("crm_atpt_cptd_cd")]
        public CrmAtptCptdCd CrmAtptCptdCd { get; set; }

        [JsonProperty("juris_desc")]
        public JurisDesc JurisDesc { get; set; }

        [JsonProperty("addr_pct_cd")]
        public string AddrPctCd { get; set; }

        [JsonProperty("loc_of_occur_desc", NullValueHandling = NullValueHandling.Ignore)]
        public LocOfOccurDesc? LocOfOccurDesc { get; set; }

        [JsonProperty("cmplnt_to_tm", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CmplntToTm { get; set; }

        [JsonProperty("cmplnt_to_dt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CmplntToDt { get; set; }

        [JsonProperty("hadevelopt", NullValueHandling = NullValueHandling.Ignore)]
        public string Hadevelopt { get; set; }

        [JsonProperty("location_1", NullValueHandling = NullValueHandling.Ignore)]
        public Location1 Location1 { get; set; }

        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Latitude { get; set; }

        [JsonProperty("x_coord_cd", NullValueHandling = NullValueHandling.Ignore)]
        public string XCoordCd { get; set; }

        [JsonProperty("y_coord_cd", NullValueHandling = NullValueHandling.Ignore)]
        public string YCoordCd { get; set; }

        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public string Longitude { get; set; }

        [JsonProperty("parks_nm", NullValueHandling = NullValueHandling.Ignore)]
        public string ParksNm { get; set; }
    }

    public partial class Location1
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("needs_recoding")]
        public bool NeedsRecoding { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public enum BoroNm { Bronx, Brooklyn, Manhattan, Queens, StatenIsland };

    public enum CrmAtptCptdCd { Attempted, Completed };

    public enum JurisDesc { DeptOfCorrections, NYHousingPolice, NYPoliceDept, NYTransitPolice, Other, PortAuthority };

    public enum LawCatCd { Felony, Misdemeanor, Violation };

    public enum LocOfOccurDesc { FrontOf, Inside, OppositeOf, RearOf };

    public enum OfnsDesc { AdministrativeCode, Arson, Assault3RelatedOffenses, Burglary, CriminalMischiefRelatedOf, CriminalTrespass, DangerousDrugs, DangerousWeapons, FelonyAssault, Forgery, Frauds, GrandLarceny, GrandLarcenyOfMotorVehicle, Harrassment2, IntoxicatedImpairedDriving, MiscellaneousPenalLaw, OffAgnstPubOrdSensblty, OffensesAgainstPublicAdmini, OffensesAgainstThePerson, OffensesInvolvingFraud, OtherOffensesRelatedToThef, PetitLarceny, PossessionOfStolenProperty, Rape, Robbery, SexCrimes, TheftFraud, UnauthorizedUseOfAVehicle, VehicleAndTrafficLaws };

    public partial class Crime
    {
        public static List<Crime> FromJson(string json) => JsonConvert.DeserializeObject<List<Crime>>(json, QuickType.Converter.Settings);
    }

    static class BoroNmExtensions
    {
        public static BoroNm? ValueForString(string str)
        {
            switch (str)
            {
                case "BRONX": return BoroNm.Bronx;
                case "BROOKLYN": return BoroNm.Brooklyn;
                case "MANHATTAN": return BoroNm.Manhattan;
                case "QUEENS": return BoroNm.Queens;
                case "STATEN ISLAND": return BoroNm.StatenIsland;
                default: return null;
            }
        }

        public static BoroNm ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this BoroNm value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case BoroNm.Bronx: serializer.Serialize(writer, "BRONX"); break;
                case BoroNm.Brooklyn: serializer.Serialize(writer, "BROOKLYN"); break;
                case BoroNm.Manhattan: serializer.Serialize(writer, "MANHATTAN"); break;
                case BoroNm.Queens: serializer.Serialize(writer, "QUEENS"); break;
                case BoroNm.StatenIsland: serializer.Serialize(writer, "STATEN ISLAND"); break;
            }
        }
    }

    static class CrmAtptCptdCdExtensions
    {
        public static CrmAtptCptdCd? ValueForString(string str)
        {
            switch (str)
            {
                case "ATTEMPTED": return CrmAtptCptdCd.Attempted;
                case "COMPLETED": return CrmAtptCptdCd.Completed;
                default: return null;
            }
        }

        public static CrmAtptCptdCd ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this CrmAtptCptdCd value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case CrmAtptCptdCd.Attempted: serializer.Serialize(writer, "ATTEMPTED"); break;
                case CrmAtptCptdCd.Completed: serializer.Serialize(writer, "COMPLETED"); break;
            }
        }
    }

    static class JurisDescExtensions
    {
        public static JurisDesc? ValueForString(string str)
        {
            switch (str)
            {
                case "DEPT OF CORRECTIONS": return JurisDesc.DeptOfCorrections;
                case "N.Y. HOUSING POLICE": return JurisDesc.NYHousingPolice;
                case "N.Y. POLICE DEPT": return JurisDesc.NYPoliceDept;
                case "N.Y. TRANSIT POLICE": return JurisDesc.NYTransitPolice;
                case "OTHER": return JurisDesc.Other;
                case "PORT AUTHORITY": return JurisDesc.PortAuthority;
                default: return null;
            }
        }

        public static JurisDesc ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this JurisDesc value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case JurisDesc.DeptOfCorrections: serializer.Serialize(writer, "DEPT OF CORRECTIONS"); break;
                case JurisDesc.NYHousingPolice: serializer.Serialize(writer, "N.Y. HOUSING POLICE"); break;
                case JurisDesc.NYPoliceDept: serializer.Serialize(writer, "N.Y. POLICE DEPT"); break;
                case JurisDesc.NYTransitPolice: serializer.Serialize(writer, "N.Y. TRANSIT POLICE"); break;
                case JurisDesc.Other: serializer.Serialize(writer, "OTHER"); break;
                case JurisDesc.PortAuthority: serializer.Serialize(writer, "PORT AUTHORITY"); break;
            }
        }
    }

    static class LawCatCdExtensions
    {
        public static LawCatCd? ValueForString(string str)
        {
            switch (str)
            {
                case "FELONY": return LawCatCd.Felony;
                case "MISDEMEANOR": return LawCatCd.Misdemeanor;
                case "VIOLATION": return LawCatCd.Violation;
                default: return null;
            }
        }

        public static LawCatCd ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this LawCatCd value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case LawCatCd.Felony: serializer.Serialize(writer, "FELONY"); break;
                case LawCatCd.Misdemeanor: serializer.Serialize(writer, "MISDEMEANOR"); break;
                case LawCatCd.Violation: serializer.Serialize(writer, "VIOLATION"); break;
            }
        }
    }

    static class LocOfOccurDescExtensions
    {
        public static LocOfOccurDesc? ValueForString(string str)
        {
            switch (str)
            {
                case "FRONT OF": return LocOfOccurDesc.FrontOf;
                case "INSIDE": return LocOfOccurDesc.Inside;
                case "OPPOSITE OF": return LocOfOccurDesc.OppositeOf;
                case "REAR OF": return LocOfOccurDesc.RearOf;
                default: return null;
            }
        }

        public static LocOfOccurDesc ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this LocOfOccurDesc value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case LocOfOccurDesc.FrontOf: serializer.Serialize(writer, "FRONT OF"); break;
                case LocOfOccurDesc.Inside: serializer.Serialize(writer, "INSIDE"); break;
                case LocOfOccurDesc.OppositeOf: serializer.Serialize(writer, "OPPOSITE OF"); break;
                case LocOfOccurDesc.RearOf: serializer.Serialize(writer, "REAR OF"); break;
            }
        }
    }

    static class OfnsDescExtensions
    {
        public static OfnsDesc? ValueForString(string str)
        {
            switch (str)
            {
                case "ADMINISTRATIVE CODE": return OfnsDesc.AdministrativeCode;
                case "ARSON": return OfnsDesc.Arson;
                case "ASSAULT 3 & RELATED OFFENSES": return OfnsDesc.Assault3RelatedOffenses;
                case "BURGLARY": return OfnsDesc.Burglary;
                case "CRIMINAL MISCHIEF & RELATED OF": return OfnsDesc.CriminalMischiefRelatedOf;
                case "CRIMINAL TRESPASS": return OfnsDesc.CriminalTrespass;
                case "DANGEROUS DRUGS": return OfnsDesc.DangerousDrugs;
                case "DANGEROUS WEAPONS": return OfnsDesc.DangerousWeapons;
                case "FELONY ASSAULT": return OfnsDesc.FelonyAssault;
                case "FORGERY": return OfnsDesc.Forgery;
                case "FRAUDS": return OfnsDesc.Frauds;
                case "GRAND LARCENY": return OfnsDesc.GrandLarceny;
                case "GRAND LARCENY OF MOTOR VEHICLE": return OfnsDesc.GrandLarcenyOfMotorVehicle;
                case "HARRASSMENT 2": return OfnsDesc.Harrassment2;
                case "INTOXICATED & IMPAIRED DRIVING": return OfnsDesc.IntoxicatedImpairedDriving;
                case "MISCELLANEOUS PENAL LAW": return OfnsDesc.MiscellaneousPenalLaw;
                case "OFF. AGNST PUB ORD SENSBLTY &": return OfnsDesc.OffAgnstPubOrdSensblty;
                case "OFFENSES AGAINST PUBLIC ADMINI": return OfnsDesc.OffensesAgainstPublicAdmini;
                case "OFFENSES AGAINST THE PERSON": return OfnsDesc.OffensesAgainstThePerson;
                case "OFFENSES INVOLVING FRAUD": return OfnsDesc.OffensesInvolvingFraud;
                case "OTHER OFFENSES RELATED TO THEF": return OfnsDesc.OtherOffensesRelatedToThef;
                case "PETIT LARCENY": return OfnsDesc.PetitLarceny;
                case "POSSESSION OF STOLEN PROPERTY": return OfnsDesc.PossessionOfStolenProperty;
                case "RAPE": return OfnsDesc.Rape;
                case "ROBBERY": return OfnsDesc.Robbery;
                case "SEX CRIMES": return OfnsDesc.SexCrimes;
                case "THEFT-FRAUD": return OfnsDesc.TheftFraud;
                case "UNAUTHORIZED USE OF A VEHICLE": return OfnsDesc.UnauthorizedUseOfAVehicle;
                case "VEHICLE AND TRAFFIC LAWS": return OfnsDesc.VehicleAndTrafficLaws;
                default: return null;
            }
        }

        public static OfnsDesc ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this OfnsDesc value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case OfnsDesc.AdministrativeCode: serializer.Serialize(writer, "ADMINISTRATIVE CODE"); break;
                case OfnsDesc.Arson: serializer.Serialize(writer, "ARSON"); break;
                case OfnsDesc.Assault3RelatedOffenses: serializer.Serialize(writer, "ASSAULT 3 & RELATED OFFENSES"); break;
                case OfnsDesc.Burglary: serializer.Serialize(writer, "BURGLARY"); break;
                case OfnsDesc.CriminalMischiefRelatedOf: serializer.Serialize(writer, "CRIMINAL MISCHIEF & RELATED OF"); break;
                case OfnsDesc.CriminalTrespass: serializer.Serialize(writer, "CRIMINAL TRESPASS"); break;
                case OfnsDesc.DangerousDrugs: serializer.Serialize(writer, "DANGEROUS DRUGS"); break;
                case OfnsDesc.DangerousWeapons: serializer.Serialize(writer, "DANGEROUS WEAPONS"); break;
                case OfnsDesc.FelonyAssault: serializer.Serialize(writer, "FELONY ASSAULT"); break;
                case OfnsDesc.Forgery: serializer.Serialize(writer, "FORGERY"); break;
                case OfnsDesc.Frauds: serializer.Serialize(writer, "FRAUDS"); break;
                case OfnsDesc.GrandLarceny: serializer.Serialize(writer, "GRAND LARCENY"); break;
                case OfnsDesc.GrandLarcenyOfMotorVehicle: serializer.Serialize(writer, "GRAND LARCENY OF MOTOR VEHICLE"); break;
                case OfnsDesc.Harrassment2: serializer.Serialize(writer, "HARRASSMENT 2"); break;
                case OfnsDesc.IntoxicatedImpairedDriving: serializer.Serialize(writer, "INTOXICATED & IMPAIRED DRIVING"); break;
                case OfnsDesc.MiscellaneousPenalLaw: serializer.Serialize(writer, "MISCELLANEOUS PENAL LAW"); break;
                case OfnsDesc.OffAgnstPubOrdSensblty: serializer.Serialize(writer, "OFF. AGNST PUB ORD SENSBLTY &"); break;
                case OfnsDesc.OffensesAgainstPublicAdmini: serializer.Serialize(writer, "OFFENSES AGAINST PUBLIC ADMINI"); break;
                case OfnsDesc.OffensesAgainstThePerson: serializer.Serialize(writer, "OFFENSES AGAINST THE PERSON"); break;
                case OfnsDesc.OffensesInvolvingFraud: serializer.Serialize(writer, "OFFENSES INVOLVING FRAUD"); break;
                case OfnsDesc.OtherOffensesRelatedToThef: serializer.Serialize(writer, "OTHER OFFENSES RELATED TO THEF"); break;
                case OfnsDesc.PetitLarceny: serializer.Serialize(writer, "PETIT LARCENY"); break;
                case OfnsDesc.PossessionOfStolenProperty: serializer.Serialize(writer, "POSSESSION OF STOLEN PROPERTY"); break;
                case OfnsDesc.Rape: serializer.Serialize(writer, "RAPE"); break;
                case OfnsDesc.Robbery: serializer.Serialize(writer, "ROBBERY"); break;
                case OfnsDesc.SexCrimes: serializer.Serialize(writer, "SEX CRIMES"); break;
                case OfnsDesc.TheftFraud: serializer.Serialize(writer, "THEFT-FRAUD"); break;
                case OfnsDesc.UnauthorizedUseOfAVehicle: serializer.Serialize(writer, "UNAUTHORIZED USE OF A VEHICLE"); break;
                case OfnsDesc.VehicleAndTrafficLaws: serializer.Serialize(writer, "VEHICLE AND TRAFFIC LAWS"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this List<Crime> self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BoroNm) || t == typeof(CrmAtptCptdCd) || t == typeof(JurisDesc) || t == typeof(LawCatCd) || t == typeof(LocOfOccurDesc) || t == typeof(OfnsDesc) || t == typeof(BoroNm?) || t == typeof(CrmAtptCptdCd?) || t == typeof(JurisDesc?) || t == typeof(LawCatCd?) || t == typeof(LocOfOccurDesc?) || t == typeof(OfnsDesc?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(BoroNm))
                return BoroNmExtensions.ReadJson(reader, serializer);
            if (t == typeof(CrmAtptCptdCd))
                return CrmAtptCptdCdExtensions.ReadJson(reader, serializer);
            if (t == typeof(JurisDesc))
                return JurisDescExtensions.ReadJson(reader, serializer);
            if (t == typeof(LawCatCd))
                return LawCatCdExtensions.ReadJson(reader, serializer);
            if (t == typeof(LocOfOccurDesc))
                return LocOfOccurDescExtensions.ReadJson(reader, serializer);
            if (t == typeof(OfnsDesc))
                return OfnsDescExtensions.ReadJson(reader, serializer);
            if (t == typeof(BoroNm?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return BoroNmExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(CrmAtptCptdCd?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return CrmAtptCptdCdExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(JurisDesc?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return JurisDescExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(LawCatCd?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return LawCatCdExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(LocOfOccurDesc?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return LocOfOccurDescExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(OfnsDesc?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return OfnsDescExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(BoroNm))
            {
                ((BoroNm)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(CrmAtptCptdCd))
            {
                ((CrmAtptCptdCd)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(JurisDesc))
            {
                ((JurisDesc)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(LawCatCd))
            {
                ((LawCatCd)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(LocOfOccurDesc))
            {
                ((LocOfOccurDesc)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(OfnsDesc))
            {
                ((OfnsDesc)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

