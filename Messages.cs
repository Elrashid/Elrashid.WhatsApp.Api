using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Elrashid.WhatsApp.Api.Messages
{
    public class WAppMsgApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _phoneNumberId;
        private readonly string _accessToken;

        public WAppMsgApiClient(string baseUrl, string phoneNumberId, string accessToken)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
            _phoneNumberId = phoneNumberId;
            _accessToken = accessToken;

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        }

        public async Task<WAppMsgResponse> SendMessageAsync(WAppMsgRequest messageRequest)
        {
            var url = $"{_baseUrl}/{_phoneNumberId}/messages";
            var json = JsonSerializer.Serialize(messageRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WAppMsgResponse>(responseBody);
        }
    }

    public class WAppMsgRequest
    {
        [JsonPropertyName("messaging_product")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgProduct? MessagingProduct { get; set; }

        [JsonPropertyName("recipient_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgRecipientType? RecipientType { get; set; }

        [JsonPropertyName("to")]
        public string? To { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgType? Type { get; set; }

        [JsonPropertyName("text")]
        public WAppMsgTextContent? Text { get; set; }

        [JsonPropertyName("image")]
        public WAppMsgMediaContent? Image { get; set; }

        [JsonPropertyName("document")]
        public WAppMsgMediaContent? Document { get; set; }

        [JsonPropertyName("audio")]
        public WAppMsgMediaContent? Audio { get; set; }

        [JsonPropertyName("video")]
        public WAppMsgMediaContent? Video { get; set; }

        [JsonPropertyName("sticker")]
        public WAppMsgMediaContent? Sticker { get; set; }

        [JsonPropertyName("location")]
        public WAppMsgLocationContent? Location { get; set; }

        [JsonPropertyName("contacts")]
        public WAppMsgContactsContent? Contacts { get; set; }

        [JsonPropertyName("interactive")]
        public WAppMsgInteractiveContent? Interactive { get; set; }

        public WAppMsgRequest(string to, WAppMsgType type, WAppMsgProduct? messagingProduct = WAppMsgProduct.Whatsapp, WAppMsgRecipientType? recipientType = WAppMsgRecipientType.Individual)
        {
            To = to ?? throw new ArgumentNullException(nameof(to));
            Type = type;
            MessagingProduct = messagingProduct;
            RecipientType = recipientType;
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgProduct
    {
        Whatsapp
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgRecipientType
    {
        Individual
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgType
    {
        Text,
        Image,
        Document,
        Audio,
        Video,
        Sticker,
        Location,
        Contacts,
        Interactive
    }

    public class WAppMsgTextContent
    {
        [JsonPropertyName("body")]
        public string? Body { get; set; }

        [JsonPropertyName("preview_url")]
        public bool? PreviewUrl { get; set; }

        public WAppMsgTextContent(string body)
        {
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }
    }

    public class WAppMsgMediaContent
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("caption")]
        public string? Caption { get; set; }

        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        public WAppMsgMediaContent(string idOrLink)
        {
            if (string.IsNullOrEmpty(idOrLink))
                throw new ArgumentNullException(nameof(idOrLink));
            if (Uri.IsWellFormedUriString(idOrLink, UriKind.Absolute))
                Link = idOrLink;
            else
                Id = idOrLink;
        }
    }

    public class WAppMsgLocationContent
    {
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        public WAppMsgLocationContent(double latitude, double longitude, string name, string address)
        {
            Latitude = latitude;
            Longitude = longitude;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }

    public class WAppMsgContactsContent
    {
        [JsonPropertyName("contacts")]
        public WAppMsgContact[]? Contacts { get; set; }

        public WAppMsgContactsContent(WAppMsgContact[] contacts)
        {
            Contacts = contacts ?? throw new ArgumentNullException(nameof(contacts));
        }
    }

    public class WAppMsgContact
    {
        [JsonPropertyName("addresses")]
        public WAppMsgAddress[]? Addresses { get; set; }

        [JsonPropertyName("birthday")]
        public string? Birthday { get; set; }

        [JsonPropertyName("emails")]
        public WAppMsgEmail[]? Emails { get; set; }

        [JsonPropertyName("name")]
        public WAppMsgName? Name { get; set; }

        [JsonPropertyName("org")]
        public WAppMsgOrganization? Org { get; set; }

        [JsonPropertyName("phones")]
        public WAppMsgPhone[]? Phones { get; set; }

        [JsonPropertyName("urls")]
        public WAppMsgUrl[]? Urls { get; set; }
    }

    public class WAppMsgAddress
    {
        [JsonPropertyName("street")]
        public string? Street { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("zip")]
        public string? Zip { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgAddressType? Type { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgAddressType
    {
        Home,
        Work
    }

    public class WAppMsgEmail
    {
        [JsonPropertyName("email")]
        public string? EmailAddress { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgEmailType? Type { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgEmailType
    {
        Home,
        Work
    }

    public class WAppMsgName
    {
        [JsonPropertyName("formatted_name")]
        public string? FormattedName { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("suffix")]
        public string? Suffix { get; set; }

        [JsonPropertyName("prefix")]
        public string? Prefix { get; set; }

        public WAppMsgName(string formattedName)
        {
            FormattedName = formattedName ?? throw new ArgumentNullException(nameof(formattedName));
        }
    }

    public class WAppMsgOrganization
    {
        [JsonPropertyName("company")]
        public string? Company { get; set; }

        [JsonPropertyName("department")]
        public string? Department { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }
    }

    public class WAppMsgPhone
    {
        [JsonPropertyName("phone")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgPhoneType? Type { get; set; }

        [JsonPropertyName("wa_id")]
        public string? WaId { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgPhoneType
    {
        Cell,
        Main,
        IPhone,
        Home,
        Work
    }

    public class WAppMsgUrl
    {
        [JsonPropertyName("url")]
        public string? UrlAddress { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgUrlType? Type { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgUrlType
    {
        Home,
        Work
    }

    public class WAppMsgInteractiveContent
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgInteractiveType? Type { get; set; }

        [JsonPropertyName("header")]
        public WAppMsgHeader? Header { get; set; }

        [JsonPropertyName("body")]
        public WAppMsgBody? Body { get; set; }

        [JsonPropertyName("footer")]
        public WAppMsgFooter? Footer { get; set; }

        [JsonPropertyName("action")]
        public WAppMsgAction? Action { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgInteractiveType
    {
        Button,
        List,
        Product,
        ProductList,
        CatalogMessage,
        Flow
    }

    public class WAppMsgHeader
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgHeaderType? Type { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("document")]
        public WAppMsgMediaContent? Document { get; set; }

        [JsonPropertyName("image")]
        public WAppMsgMediaContent? Image { get; set; }

        [JsonPropertyName("video")]
        public WAppMsgMediaContent? Video { get; set; }

        public WAppMsgHeader(WAppMsgHeaderType type)
        {
            Type = type;
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgHeaderType
    {
        Text,
        Image,
        Document,
        Video
    }

    public class WAppMsgBody
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        public WAppMsgBody(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }

    public class WAppMsgFooter
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        public WAppMsgFooter(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }

    public class WAppMsgAction
    {
        [JsonPropertyName("button")]
        public string? Button { get; set; }

        [JsonPropertyName("buttons")]
        public WAppMsgButton[]? Buttons { get; set; }

        [JsonPropertyName("catalog_id")]
        public string? CatalogId { get; set; }

        [JsonPropertyName("product_retailer_id")]
        public string? ProductRetailerId { get; set; }

        [JsonPropertyName("sections")]
        public WAppMsgSection[]? Sections { get; set; }
    }

    public class WAppMsgButton
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppMsgButtonType? Type { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppMsgButtonType
    {
        Reply
    }

    public class WAppMsgSection
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("product_items")]
        public WAppMsgProductItem[]? ProductItems { get; set; }

        [JsonPropertyName("rows")]
        public WAppMsgRow[]? Rows { get; set; }
    }

    public class WAppMsgProductItem
    {
        [JsonPropertyName("product_retailer_id")]
        public string? ProductRetailerId { get; set; }

        public WAppMsgProductItem(string productRetailerId)
        {
            ProductRetailerId = productRetailerId ?? throw new ArgumentNullException(nameof(productRetailerId));
        }
    }

    public class WAppMsgRow
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        public WAppMsgRow(string id, string title)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
    }

    public class WAppMsgResponse
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct { get; set; }

        [JsonPropertyName("contacts")]
        public WAppMsgContactResponse[]? Contacts { get; set; }

        [JsonPropertyName("messages")]
        public WAppMsgMessageResponse[]? Messages { get; set; }
    }

    public class WAppMsgContactResponse
    {
        [JsonPropertyName("input")]
        public string? Input { get; set; }

        [JsonPropertyName("wa_id")]
        public string? WaId { get; set; }
    }

    public class WAppMsgMessageResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("message_status")]
        public string? MessageStatus { get; set; }
    }
}
