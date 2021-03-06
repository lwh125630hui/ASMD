﻿//<summary>
//  Title   : helper that contains Name and event that is raised everytime Name is changed
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.UA.Model.Designer.Wrappers;
using System;
using System.ComponentModel;

namespace CAS.UA.Model.Designer.Wrappers4ProperyGrid
{
  /// <summary>
  /// Helper that contains name of the instance.
  /// </summary>
  internal class NameWithEventBase<TModel>
    where TModel: IBaseModel
  {
    private void RaiseOnNameChangedEvent()
    {
      OnNameChanged?.Invoke(this, EventArgs.Empty);
    }
    private string m_name = "";
    private TModel m_Model;
    public NameWithEventBase(TModel model)
    {
      m_Model = model;
    }
    protected TModel ModelEntity
    {
      get { return m_Model; }
    }
    /// <summary>
    /// Gets or sets the name of the instance.
    /// </summary>
    /// <value>The name.</value>
    [DisplayName( "Name" )]
    [Category( "Input" )]
    [Description( "Project name – any text identifying the project." )]
    [NotifyParentProperty( true )]
    public string Name
    {
      get
      {
        return m_Model.Text;
      }
      set
      {
        m_Model.Text = value;
        RaiseOnNameChangedEvent();
      }
    }
    /// <summary>
    /// Occurs when the name is changed.
    /// </summary>
    public event EventHandler OnNameChanged;
  }
}
