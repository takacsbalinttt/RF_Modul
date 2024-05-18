/*
' Copyright (c) 2024 YounglingSlayer
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using System;
using System.Collections.Generic;

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models
{
    public class Settings
    {
        //Legacy Settings


        public bool MultiSelect { get; set; }

        
        public int NumberOfItems { get; set; }

        public bool proceed { get; set; }



        public List<Card> cards { get; set; } = new List<Card>();


        //New settings start from here


        public string ModuleCulture { get; set; }

        public List<Section> Sections { get; set; } = new List<Section>();

        public int NumberOfSections { get; set; }

    }
}