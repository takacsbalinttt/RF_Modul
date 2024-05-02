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

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models
{
    public class Card
    {

        /// <summary>
        /// The ID of the card
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// The section the card is in
        /// </summary>
        public int Section { get; set; }

        /// <summary>
        /// The HotCakes Item the card displays
        /// </summary>

        public HotCakes Item { get; set; }


        /// <summary>
        /// The BVIN of the HotCakes Item the card displays
        /// </summary>
        ///
        public string Bvin { get; set; }   


        /// <summary>
        /// Gets the proper name from HotCakes
        /// </summary>
        public string TranslatedName { get; set; }  


        /// <summary>
        /// Override the name of the item?
        /// </summary>

        public bool NameOverride { get; set; }

        /// <summary>
        /// To override the name of the item
        /// </summary>
        public string NameOverrideText { get; set; }
        

        /// <summary>
        /// Override the image of the item?
        /// </summary>
        public bool ImageOverride { get; set; } 

        /// <summary>
        ///  The file name of the image to override with
        /// </summary>
        public string ImageOverrideFile { get; set; }

        /// <summary>
        /// Is the card disabled?
        /// </summary>

        public bool Disable { get; set; }

        /// <summary>
        /// Is the Card Spicy?
        /// </summary>

        public bool Spicy { get; set; }

        /// <summary>
        /// Is the item missing?
        /// </summary>

        public bool ItemMissing { get; set; }

    }
}