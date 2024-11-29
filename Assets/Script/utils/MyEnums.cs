using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum OrganizationAccess{Public, MembersOnly}
[JsonConverter(typeof(StringEnumConverter))]
public enum SpaceAccess{Public, Private, Organization}
[JsonConverter(typeof(StringEnumConverter))]
public enum MembershipStatus{Basic, Pro, Plus, Unknown }
[JsonConverter(typeof(StringEnumConverter))]
public enum Gender{None, Male, Female, Other}
[JsonConverter(typeof(StringEnumConverter))]
public enum LoginType{Email}
[JsonConverter(typeof(StringEnumConverter))]
public enum PlatformType{Web, Mobile, PC ,Unknown}