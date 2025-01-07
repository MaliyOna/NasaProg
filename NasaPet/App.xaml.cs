﻿namespace NasaPet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            try
            {
                return new Window(new AppShell());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании окна: {ex.Message}");
                throw;
            }
        }
    }
}