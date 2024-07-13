using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


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
            var json = JsonConvert.SerializeObject(messageRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WAppMsgResponse>(responseBody);
        }

        public class WAppMsgRequest
        {
            [JsonProperty("messaging_product")]
            public WAppMsgProduct? MessagingProduct { get; set; }

            [JsonProperty("recipient_type")]
            public WAppMsgRecipientType? RecipientType { get; set; }

            [JsonProperty("to")]
            public string? To { get; set; }

            [JsonProperty("type")]
            public WAppMsgType? Type { get; set; }

            [JsonProperty("text")]
            public WAppMsgTextContent? Text { get; set; }

            [JsonProperty("image")]
            public WAppMsgMediaContent? Image { get; set; }

            [JsonProperty("document")]
            public WAppMsgMediaContent? Document { get; set; }

            [JsonProperty("audio")]
            public WAppMsgMediaContent? Audio { get; set; }

            [JsonProperty("video")]
            public WAppMsgMediaContent? Video { get; set; }

            [JsonProperty("sticker")]
            public WAppMsgMediaContent? Sticker { get; set; }

            [JsonProperty("location")]
            public WAppMsgLocationContent? Location { get; set; }

            [JsonProperty("contacts")]
            public WAppMsgContactsContent? Contacts { get; set; }

            [JsonProperty("interactive")]
            public WAppMsgInteractiveContent? Interactive { get; set; }

            public WAppMsgRequest(string to, WAppMsgType type, WAppMsgProduct? messagingProduct = WAppMsgProduct.Whatsapp, WAppMsgRecipientType? recipientType = WAppMsgRecipientType.Individual)
            {
                To = to ?? throw new ArgumentNullException(nameof(to));
                Type = type;
                MessagingProduct = messagingProduct;
                RecipientType = recipientType;
            }

            public enum WAppMsgProduct
            {
                Whatsapp
            }

            public enum WAppMsgRecipientType
            {
                Individual
            }

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
                [JsonProperty("body")]
                public string? Body { get; set; }

                [JsonProperty("preview_url")]
                public bool? PreviewUrl { get; set; }

                public WAppMsgTextContent(string body)
                {
                    Body = body ?? throw new ArgumentNullException(nameof(body));
                }
            }

            public class WAppMsgMediaContent
            {
                [JsonProperty("id")]
                public string? Id { get; set; }

                [JsonProperty("link")]
                public string? Link { get; set; }

                [JsonProperty("caption")]
                public string? Caption { get; set; }

                [JsonProperty("filename")]
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
                [JsonProperty("latitude")]
                public double? Latitude { get; set; }

                [JsonProperty("longitude")]
                public double? Longitude { get; set; }

                [JsonProperty("name")]
                public string? Name { get; set; }

                [JsonProperty("address")]
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
                [JsonProperty("contacts")]
                public WAppMsgContact[]? Contacts { get; set; }

                public WAppMsgContactsContent(WAppMsgContact[] contacts)
                {
                    Contacts = contacts ?? throw new ArgumentNullException(nameof(contacts));
                }

                public class WAppMsgContact
                {
                    [JsonProperty("addresses")]
                    public WAppMsgAddress[]? Addresses { get; set; }

                    [JsonProperty("birthday")]
                    public string? Birthday { get; set; }

                    [JsonProperty("emails")]
                    public WAppMsgEmail[]? Emails { get; set; }

                    [JsonProperty("name")]
                    public WAppMsgName? Name { get; set; }

                    [JsonProperty("org")]
                    public WAppMsgOrganization? Org { get; set; }

                    [JsonProperty("phones")]
                    public WAppMsgPhone[]? Phones { get; set; }

                    [JsonProperty("urls")]
                    public WAppMsgUrl[]? Urls { get; set; }

                    public class WAppMsgAddress
                    {
                        [JsonProperty("street")]
                        public string? Street { get; set; }

                        [JsonProperty("city")]
                        public string? City { get; set; }

                        [JsonProperty("state")]
                        public string? State { get; set; }

                        [JsonProperty("zip")]
                        public string? Zip { get; set; }

                        [JsonProperty("country")]
                        public string? Country { get; set; }

                        [JsonProperty("country_code")]
                        public string? CountryCode { get; set; }

                        [JsonProperty("type")]
                        public WAppMsgAddressType? Type { get; set; }

                        public enum WAppMsgAddressType
                        {
                            Home,
                            Work
                        }
                    }

                    public class WAppMsgEmail
                    {
                        [JsonProperty("email")]
                        public string? EmailAddress { get; set; }

                        [JsonProperty("type")]
                        public WAppMsgEmailType? Type { get; set; }

                        public enum WAppMsgEmailType
                        {
                            Home,
                            Work
                        }
                    }

                    public class WAppMsgName
                    {
                        [JsonProperty("formatted_name")]
                        public string? FormattedName { get; set; }

                        [JsonProperty("first_name")]
                        public string? FirstName { get; set; }

                        [JsonProperty("last_name")]
                        public string? LastName { get; set; }

                        [JsonProperty("middle_name")]
                        public string? MiddleName { get; set; }

                        [JsonProperty("suffix")]
                        public string? Suffix { get; set; }

                        [JsonProperty("prefix")]
                        public string? Prefix { get; set; }

                        public WAppMsgName(string formattedName)
                        {
                            FormattedName = formattedName ?? throw new ArgumentNullException(nameof(formattedName));
                        }
                    }

                    public class WAppMsgOrganization
                    {
                        [JsonProperty("company")]
                        public string? Company { get; set; }

                        [JsonProperty("department")]
                        public string? Department { get; set; }

                        [JsonProperty("title")]
                        public string? Title { get; set; }
                    }

                    public class WAppMsgPhone
                    {
                        [JsonProperty("phone")]
                        public string? PhoneNumber { get; set; }

                        [JsonProperty("type")]
                        public WAppMsgPhoneType? Type { get; set; }

                        [JsonProperty("wa_id")]
                        public string? WaId { get; set; }

                        public enum WAppMsgPhoneType
                        {
                            Cell,
                            Main,
                            IPhone,
                            Home,
                            Work
                        }
                    }

                    public class WAppMsgUrl
                    {
                        [JsonProperty("url")]
                        public string? UrlAddress { get; set; }

                        [JsonProperty("type")]
                        public WAppMsgUrlType? Type { get; set; }

                        public enum WAppMsgUrlType
                        {
                            Home,
                            Work
                        }
                    }
                }
            }

            public class WAppMsgInteractiveContent
            {
                [JsonProperty("type")]
                public WAppMsgInteractiveType? Type { get; set; }

                [JsonProperty("header")]
                public WAppMsgHeader? Header { get; set; }

                [JsonProperty("body")]
                public WAppMsgBody? Body { get; set; }

                [JsonProperty("footer")]
                public WAppMsgFooter? Footer { get; set; }

                [JsonProperty("action")]
                public WAppMsgAction? Action { get; set; }

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
                    [JsonProperty("type")]
                    public WAppMsgHeaderType? Type { get; set; }

                    [JsonProperty("text")]
                    public string? Text { get; set; }

                    [JsonProperty("document")]
                    public WAppMsgMediaContent? Document { get; set; }

                    [JsonProperty("image")]
                    public WAppMsgMediaContent? Image { get; set; }

                    [JsonProperty("video")]
                    public WAppMsgMediaContent? Video { get; set; }

                    public WAppMsgHeader(WAppMsgHeaderType type)
                    {
                        Type = type;
                    }

                    public enum WAppMsgHeaderType
                    {
                        Text,
                        Image,
                        Document,
                        Video
                    }
                }

                public class WAppMsgBody
                {
                    [JsonProperty("text")]
                    public string? Text { get; set; }

                    public WAppMsgBody(string text)
                    {
                        Text = text ?? throw new ArgumentNullException(nameof(text));
                    }
                }

                public class WAppMsgFooter
                {
                    [JsonProperty("text")]
                    public string? Text { get; set; }

                    public WAppMsgFooter(string text)
                    {
                        Text = text ?? throw new ArgumentNullException(nameof(text));
                    }
                }

                public class WAppMsgAction
                {
                    [JsonProperty("button")]
                    public string? Button { get; set; }

                    [JsonProperty("buttons")]
                    public WAppMsgButton[]? Buttons { get; set; }

                    [JsonProperty("catalog_id")]
                    public string? CatalogId { get; set; }

                    [JsonProperty("product_retailer_id")]
                    public string? ProductRetailerId { get; set; }

                    [JsonProperty("sections")]
                    public WAppMsgSection[]? Sections { get; set; }

                    public class WAppMsgButton
                    {
                        [JsonProperty("type")]
                        public WAppMsgButtonType? Type { get; set; }

                        [JsonProperty("title")]
                        public string? Title { get; set; }

                        [JsonProperty("id")]
                        public string? Id { get; set; }

                        public enum WAppMsgButtonType
                        {
                            Reply
                        }
                    }

                    public class WAppMsgSection
                    {
                        [JsonProperty("title")]
                        public string? Title { get; set; }

                        [JsonProperty("product_items")]
                        public WAppMsgProductItem[]? ProductItems { get; set; }

                        [JsonProperty("rows")]
                        public WAppMsgRow[]? Rows { get; set; }

                        public class WAppMsgProductItem
                        {
                            [JsonProperty("product_retailer_id")]
                            public string? ProductRetailerId { get; set; }

                            public WAppMsgProductItem(string productRetailerId)
                            {
                                ProductRetailerId = productRetailerId ?? throw new ArgumentNullException(nameof(productRetailerId));
                            }
                        }

                        public class WAppMsgRow
                        {
                            [JsonProperty("id")]
                            public string? Id { get; set; }

                            [JsonProperty("title")]
                            public string? Title { get; set; }

                            [JsonProperty("description")]
                            public string? Description { get; set; }

                            public WAppMsgRow(string id, string title)
                            {
                                Id = id ?? throw new ArgumentNullException(nameof(id));
                                Title = title ?? throw new ArgumentNullException(nameof(title));
                            }
                        }
                    }
                }
            }
        }

        public class WAppMsgResponse
        {
            [JsonProperty("messaging_product")]
            public string? MessagingProduct { get; set; }

            [JsonProperty("contacts")]
            public WAppMsgContactResponse[]? Contacts { get; set; }

            [JsonProperty("messages")]
            public WAppMsgMessageResponse[]? Messages { get; set; }

            public class WAppMsgContactResponse
            {
                [JsonProperty("input")]
                public string? Input { get; set; }

                [JsonProperty("wa_id")]
                public string? WaId { get; set; }
            }

            public class WAppMsgMessageResponse
            {
                [JsonProperty("id")]
                public string? Id { get; set; }

                [JsonProperty("message_status")]
                public string? MessageStatus { get; set; }
            }
        }
    }

}
