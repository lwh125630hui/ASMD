﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace CAS.UA.Model.Designer.Wrappers4ProperyGrid {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class UAModelDesignerSolution {
        
        private string nameField;
        
        private UAModelDesignerProject[] projectsField;
        
        private UAModelDesignerSolutionServerDetails serverDetailsField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("UAModelDesignerProject", IsNullable=false)]
        public UAModelDesignerProject[] Projects {
            get {
                return this.projectsField;
            }
            set {
                this.projectsField = value;
            }
        }
        
        /// <remarks/>
        public UAModelDesignerSolutionServerDetails ServerDetails {
            get {
                return this.serverDetailsField;
            }
            set {
                this.serverDetailsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "UAModelDesignerProject", AnonymousType=false)]
    public partial class UAModelDesignerProject {
        
        private string nameField;
        
        private string cSVFileNameField;
        
        private string buildOutputDirectoryNameField;
        
        private string fileNameField;
        
        private string projectIdentifierField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string CSVFileName {
            get {
                return this.cSVFileNameField;
            }
            set {
                this.cSVFileNameField = value;
            }
        }
        
        /// <remarks/>
        public string BuildOutputDirectoryName {
            get {
                return this.buildOutputDirectoryNameField;
            }
            set {
                this.buildOutputDirectoryNameField = value;
            }
        }
        
        /// <remarks/>
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProjectIdentifier {
            get {
                return this.projectIdentifierField;
            }
            set {
                this.projectIdentifierField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class UAModelDesignerSolutionServerDetails {
        
        private string codebaseField;
        
        private string configurationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codebase {
            get {
                return this.codebaseField;
            }
            set {
                this.codebaseField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string configuration {
            get {
                return this.configurationField;
            }
            set {
                this.configurationField = value;
            }
        }
    }
}
