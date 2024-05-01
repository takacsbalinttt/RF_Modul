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

namespace DNN.WokPickerDNN.YounglingSlayer.WokPicker.Models
{
    public class CardSection
    {
        public int sectionID { get; set; }

        public string sectionName { get; set; }

        public string sectionDescription { get; set; }

        public int cardNumber { get; set; }   
        
        public bool multiSelect { get; set; }

        public bool hide { get; set; }

        public List<CardSettings> cards { get; set; } = new List<CardSettings>();

    }
}