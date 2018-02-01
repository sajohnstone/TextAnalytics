using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;

namespace Text_Analytics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westus;
            client.SubscriptionKey = "ENTER KEY HERE";
            string languageCode = "en";

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Extracting language
            Console.WriteLine("Please enter a sentance (in english):");
            string s = Console.ReadLine();
            Console.WriteLine("Processing....");

            MultiLanguageBatchInput b = new MultiLanguageBatchInput(new List<MultiLanguageInput>() { new MultiLanguageInput(languageCode, null, s) });

            KeyPhraseBatchResult phraseRes = client.KeyPhrases(b);
            SentimentBatchResult sentimentRes = client.Sentiment(b);

            Console.WriteLine(string.Format("Key Phrases: {0}", phraseRes.Documents[0].KeyPhrases));
            Console.WriteLine(string.Format("Key Phrases: {0:0.00}", sentimentRes.Documents[0].Score));

        }
    }
}