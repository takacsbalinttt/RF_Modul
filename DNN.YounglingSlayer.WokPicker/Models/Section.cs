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
    public class Section
    {
        /// <summary>
        /// The ID of the section
        /// </summary>
        public int SectionID { get; set; }

        /// <summary>
        /// The name of the section
        /// </summary>
        public string SectionName { get; set; }

        /// <summary>
        /// The description of the section
        /// </summary>
        public string SectionDescription { get; set; }

        /// <summary>
        /// The number of cards in the section
        /// </summary>

        public int CardCount { get; set; }   
        
        /// <summary>
        /// Is the section in MultiSelect mode
        /// </summary>

        public bool MultiSelect { get; set; }

        /// <summary>
        /// Is the section hidden
        /// </summary>

        public bool Hide { get; set; }

        /// <summary>
        /// The list of the actual card items in the section
        /// </summary>


        public List<Card> Cards { get; set; } = new List<Card>();

    }
}