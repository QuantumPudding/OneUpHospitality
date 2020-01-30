using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;
using HelperClasses;

namespace SecureStringTextBox
{
    public partial class SecureTextBox : PromptTextBox
    {
        public SecureString SecureString { get; set; } = new SecureString();

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                ProcessBackspace();
            else
                ProcessNewCharacter(e.KeyChar);

            e.Handled = true;
        }

        private void ProcessNewCharacter(char character)
        {
            if (SelectionLength > 0)
            {
                RemoveSelectedCharacters();
            }

            SecureString.InsertAt(SelectionStart, character);
            ResetDisplayCharacters(SelectionStart + 1);
        }

        private void RemoveSelectedCharacters()
        {
            for (int i = 0; i < SelectionLength; i++)
            {
                SecureString.RemoveAt(SelectionStart);
            }
        }

        private void ResetDisplayCharacters(int caretPosition)
        {
            Text = new string(PasswordChar, SecureString.Length);
            SelectionStart = caretPosition;
        }

        private void ProcessBackspace()
        {
            if (SelectionLength > 0)
            {
                RemoveSelectedCharacters();
                ResetDisplayCharacters(SelectionStart);
            }
            else if (SelectionStart > 0)
            {
                SecureString.RemoveAt(SelectionStart - 1);
                ResetDisplayCharacters(SelectionStart - 1);
            }
        }

        protected new void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ProcessDelete();
                e.Handled = true;
            }
            else if (IsIgnorableKey(e.KeyCode))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private bool IsIgnorableKey(Keys key)
        {
            return key == Keys.Escape || key == Keys.Enter;
        }

        private void ProcessDelete()
        {
            if (SelectionLength > 0)
            {
                RemoveSelectedCharacters();
            }
            else if (SelectionStart < Text.Length)
            {
                SecureString.RemoveAt(SelectionStart);
            }

            ResetDisplayCharacters(SelectionStart);
        }
    }
}
