namespace WhatAppIntegration.Domain
{
    internal class LogDomain
    {
        private string LogFilePath => Path.Combine(AppContext.BaseDirectory, $"LogWhatsApp-{DateTime.Now:yyyy-MM-dd}.txt");

        internal void LogMessage(string from, string body)
        {
            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now} - From: {from} - Message: {body}");
            }
        }
    }
}
