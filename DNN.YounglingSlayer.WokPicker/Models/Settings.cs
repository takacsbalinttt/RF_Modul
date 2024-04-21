﻿/*
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
using System.Linq;
using System.Web;

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models
{
    public class Settings
    {
        public bool MultiSelect { get; set; }
        public DateTime Setting2 { get; set; }
        public string ItemID1 { get; set; }
        public string ItemName1 { get; set;}
        public string ItemImagePath1 { get; set; }

        public string ItemID2 { get; set;}
        public string ItemName2 { get; set;}   
        public string ItemImagePath2 { get; set; }  

        public string ItemID3 { get; set;}
        public string ItemName3 { get; set;}   
        public string ItemImagePath3 { get;set;}
    }
}