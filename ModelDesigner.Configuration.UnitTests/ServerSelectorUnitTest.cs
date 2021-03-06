﻿//___________________________________________________________________________________
//
//  Copyright (C) 2019, Mariusz Postol LODZ POLAND.
//
//___________________________________________________________________________________

using CAS.CommServer.UA.Common;
using CAS.CommServer.UA.ModelDesigner.Configuration.UserInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CAS.CommServer.UA.ModelDesigner.Configuration.UnitTests
{
  [TestClass]
  public class ServerSelectorUnitTest
  {

    [TestMethod]
    public void ServerSelectorCreatorTest()
    {
      TestGraphicalUserInterface _tg = new TestGraphicalUserInterface();
      ServerSelector _nss = new ServerSelector(_tg, "", "", "");
      Assert.IsNull(_nss.SelectedAssembly);
      Assert.IsNull(_nss.ServerConfiguration);
      Assert.IsNull(_nss.IServerConfiguration);
    }
    [TestMethod]
    public void ServerConfigurationNullTest()
    {
      TestGraphicalUserInterface _tg = new TestGraphicalUserInterface();
      ServerSelector _nss = new ServerSelector(_tg, "", "", "");
      Assert.IsFalse(_tg.WarningCalled);
    }
    [TestMethod]
    public void ServerConfigurationWrongAssemblyTest()
    {
      TestGraphicalUserInterface _tgi = new TestGraphicalUserInterface();
      ServerSelector _nss = new ServerSelector(_tgi, "wrong_path", "wrong.codebase", "wrong.configuration");
      Assert.IsTrue(_tgi.WarningCalled);
      Assert.IsTrue(_tgi.WarningMessage.Contains("wrong.codebase"));
      Assert.AreEqual<string>("Open configuration editor", _tgi.WarningCaption);
    }
    [TestMethod]
    public void ServerConfigurationWTest()
    {
      TestGraphicalUserInterface _ui = new TestGraphicalUserInterface();
      ServerSelector _nss = new ServerSelector(_ui, "wrong_path", "CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.dll", "");
      Assert.AreEqual<int>(2, _ui.ExclamationCallCount);
      Assert.AreEqual<int>(0, _ui.ErrorCallCount);
      Assert.AreEqual<int>(0, _ui.OpenFileDialog4UnitTestAssertErrors);
      CollectionAssert.AreEqual(new string[] { }, _ui.ErrorCaption);
      CollectionAssert.AreEqual(new string[] { }, _ui.ErrorMessage);
      CollectionAssert.AreEqual(new string[] { "No configuration file has been selected!", "No folder is selected" }, _ui.ExclamationCaption);
      CollectionAssert.AreEqual(new string[] { "You did not choose the configuration file. Please select a location of the default configuration file.",
                                               "Folder is not selected, configuration will be created in the default location." }, _ui.ExclamationMessage);
    }
    [TestMethod]
    public void EmptyServerDescriptorTest()
    {
      TestGraphicalUserInterface _ui = new TestGraphicalUserInterface();
      ServerSelector _nss = new ServerSelector(_ui, string.Empty, string.Empty, string.Empty);
      Assert.IsFalse(_ui.WarningCalled);
    }

    #region Instrumentation
    private class OpenFileDialog4UnitTest : IFileDialog
    {
      private string m_DefaultExt;
      private readonly Action m_ReportAssertError;
      public OpenFileDialog4UnitTest(Action reportAssertError)
      {
        if (reportAssertError == null)
          throw new NullReferenceException(nameof(reportAssertError));
        m_ReportAssertError = reportAssertError;
      }
      /// <summary>
      /// Gets or sets the default file name extension.
      /// </summary>
      /// <value>The default file name extension. The returned string does not include the period. The default value is an empty string ("")</value>
      public string DefaultExt
      {
        get => m_DefaultExt;
        set
        {
          m_DefaultExt = value.Replace(".", "");
          if (string.Compare("uasconfig", m_DefaultExt) != 0)
            m_ReportAssertError();
        }
      }
      public string FileName
      {
        get => throw new NotImplementedException();
        set
        {
          if (string.Compare("CAS.UAServer.Configuration", value) != 0)
            m_ReportAssertError();
        }
      }
      public string Filter
      {
        get => throw new NotImplementedException();
        set
        {
          if (string.Compare(@"Configuration (* .uasconfig)|*.uasconfig|(* .xml)|*.xml|All files (*.*)|*.*", value) != 0)
            m_ReportAssertError();
        }
      }
      public string InitialDirectory
      {
        get => throw new NotImplementedException();

        set => throw new NotImplementedException();
      }
      public string Title
      {
        get => throw new NotImplementedException();
        set
        {
          if (string.Compare("UA Server configuration file", value) != 0)
            m_ReportAssertError();
        }
      }
      public void Dispose() { }
      public bool ShowDialog()
      {
        return false;
      }
    }
    private class FolderBrowserDialog : IFolderBrowserDialog
    {
      public string SelectedPath
      {
        get => Environment.CurrentDirectory;
        set => throw new NotImplementedException();
      }
      public void Dispose() { }
      public bool ShowDialog() { return false; }
    }
    private class TestGraphicalUserInterface : IGraphicalUserInterface
    {

      internal List<string> ErrorCaption = new List<string>();
      internal List<string> ErrorMessage = new List<string>();
      internal List<string> ExclamationCaption = new List<string>();
      internal List<string> ExclamationMessage = new List<string>();
      internal string WarningMessage;
      internal string WarningCaption;
      internal int ErrorCallCount = 0;
      internal int ExclamationCallCount = 0;
      internal bool WarningCalled;
      internal int OpenFileDialog4UnitTestAssertErrors = 0;

      public TestGraphicalUserInterface()
      {
        MessageBoxShowWarning = MessageBoxShowMethod;
        OpenFileDialogFunc = () => new OpenFileDialog4UnitTest(() => OpenFileDialog4UnitTestAssertErrors++);
      }
      public Action<string, string> MessageBoxShowWarning
      {
        get; set;
      }
      public Func<IFileDialog> OpenFileDialogFunc
      {
        get;
        private set;
      }
      public Action<string, string> MessageBoxShowExclamation => (x, y) => { ExclamationCaption.Add(y); ExclamationMessage.Add(x); ExclamationCallCount++; };
      public Action<string, string> MessageBoxShowError => (x, y) => { ErrorCaption.Add(y); ErrorMessage.Add(x); ErrorCallCount++; };
      public Func<IFileDialog> SaveFileDialogFuc => throw new NotImplementedException();
      public Func<IFolderBrowserDialog> OpenFolderBrowserDialogFunc => () => new FolderBrowserDialog();
      public Func<string, string, bool> MessageBoxShowWarningAskYN => throw new NotImplementedException();
      public bool UseWaitCursor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
      private void MessageBoxShowMethod(string text, string caption)
      {
        WarningCalled = true;
        WarningMessage = text;
        WarningCaption = caption;
      }

    }
    #endregion

  }
}
