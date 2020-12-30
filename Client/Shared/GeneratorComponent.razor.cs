﻿using Blazorise;
using Blazorise.Snackbar;
using CurrieTechnologies.Razor.Clipboard;
using Microsoft.AspNetCore.Components;
using PasswordHashGenerator.Shared.Extensions;
using PasswordHashGenerator.Shared.Handlers;
using PasswordHashGenerator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordHashGenerator.Client.Shared
{
    public partial class GeneratorComponent
    {
        public SnackbarStack Toast { get; set; }
        public GeneratorOptions Options { get; set; }
        public string GeneratedPassword { get; set; }
        public TextEdit Identifier { get; set; }

        [Inject]
        public ClipboardService clipboard { get; set; }

        public void ResetClicked()
        {
            Options.Identifier = null;
            Options.MasterPassword = null;
            GeneratedPassword = null;
            Identifier.Focus();
            UiSuccess("Reset successful");
        }

        private void UiSuccess(string msg)
        {
            Toast.Push(msg, SnackbarColor.Success);
        }

        private void UiWarning(string msg)
        {
            Toast.Push(msg, SnackbarColor.Warning);
        }

        private void UiError(string msg)
        {
            Toast.Push(msg, SnackbarColor.Danger);
        }

        private void UiMessage(string msg, SnackbarColor color)
        {
            Toast.Push(msg, color);
        }

        public void GenerateClicked()
        {
            try
            {
                var generator = PasswordGeneratorHandler.FindGenerators(Options.Algorithm).First();
                GeneratedPassword = generator.Generate(Options);
                UiSuccess("Generated successful");
            }
            catch (Exception ex)
            {
                UiError($"Could not generate password: {ex.Message}");
            }
        }

        public async Task CopyClicked()
        {
            try
            {
                if (GeneratedPassword.IsNullOrEmpty())
                {
                    throw new NullReferenceException("No password to copy");
                }

                await clipboard.WriteTextAsync(GeneratedPassword);
                UiSuccess("Password copied");
            }
            catch (Exception ex)
            {
                UiError($"Can not copy password: {ex.Message}");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Options = new GeneratorOptions();
            await base.OnInitializedAsync();
        }
    }
}