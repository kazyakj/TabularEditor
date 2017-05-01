// Code generated by a template
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using TabularEditor.PropertyGridUI;
using TabularEditor.UndoFramework;
using TOM = Microsoft.AnalysisServices.Tabular;

namespace TabularEditor.TOMWrapper
{
  
    /// <summary>
	/// Base class declaration for Table
	/// </summary>
	[TypeConverter(typeof(DynamicPropertyConverter))]
	public partial class Table: TabularNamedObject, IHideableObject, IDescriptionObject, IAnnotationObject, ITranslatableObject
	{
	    protected internal new TOM.Table MetadataObject { get { return base.MetadataObject as TOM.Table; } internal set { base.MetadataObject = value; } }

		public string GetAnnotation(string name) {
		    return MetadataObject.Annotations.Find(name)?.Value;
		}
		public void SetAnnotation(string name, string value, bool undoable = true) {
			if(MetadataObject.Annotations.Contains(name)) {
				MetadataObject.Annotations[name].Value = value;
			} else {
				MetadataObject.Annotations.Add(new TOM.Annotation{ Name = name, Value = value });
			}
			if (undoable) Handler.UndoManager.Add(new UndoAnnotationAction(this, name, value));
		}
		        /// <summary>
        /// Gets or sets the DataCategory of the Table.
        /// </summary>
		[DisplayName("Data Category")]
		[Category("Metadata"),IntelliSense("The Data Category of this Table.")]
		public string DataCategory {
			get {
			    return MetadataObject.DataCategory;
			}
			set {
				var oldValue = DataCategory;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("DataCategory", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.DataCategory = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "DataCategory", oldValue, value));
				OnPropertyChanged("DataCategory", oldValue, value);
			}
		}
		private bool ShouldSerializeDataCategory() { return false; }
        /// <summary>
        /// Gets or sets the Description of the Table.
        /// </summary>
		[DisplayName("Description")]
		[Category("Basic"),IntelliSense("The Description of this Table.")]
		public string Description {
			get {
			    return MetadataObject.Description;
			}
			set {
				var oldValue = Description;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("Description", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.Description = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "Description", oldValue, value));
				OnPropertyChanged("Description", oldValue, value);
			}
		}
		private bool ShouldSerializeDescription() { return false; }
        /// <summary>
        /// Gets or sets the IsHidden of the Table.
        /// </summary>
		[DisplayName("Hidden")]
		[Category("Basic"),IntelliSense("The Hidden of this Table.")]
		public bool IsHidden {
			get {
			    return MetadataObject.IsHidden;
			}
			set {
				var oldValue = IsHidden;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("IsHidden", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.IsHidden = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "IsHidden", oldValue, value));
				OnPropertyChanged("IsHidden", oldValue, value);
				Handler.UpdateObject(this);
			}
		}
		private bool ShouldSerializeIsHidden() { return false; }
        /// <summary>
        /// Gets or sets the ShowAsVariationsOnly of the Table.
        /// </summary>
		[DisplayName("Show As Variations Only")]
		[Category("Options"),IntelliSense("The Show As Variations Only of this Table.")]
		public bool ShowAsVariationsOnly {
			get {
			    return MetadataObject.ShowAsVariationsOnly;
			}
			set {
				var oldValue = ShowAsVariationsOnly;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("ShowAsVariationsOnly", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.ShowAsVariationsOnly = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "ShowAsVariationsOnly", oldValue, value));
				OnPropertyChanged("ShowAsVariationsOnly", oldValue, value);
			}
		}
		private bool ShouldSerializeShowAsVariationsOnly() { return false; }
        /// <summary>
        /// Gets or sets the IsPrivate of the Table.
        /// </summary>
		[DisplayName("Private")]
		[Category("Options"),IntelliSense("The Private of this Table.")]
		public bool IsPrivate {
			get {
			    return MetadataObject.IsPrivate;
			}
			set {
				var oldValue = IsPrivate;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging("IsPrivate", value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.IsPrivate = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, "IsPrivate", oldValue, value));
				OnPropertyChanged("IsPrivate", oldValue, value);
			}
		}
		private bool ShouldSerializeIsPrivate() { return false; }

        /// <summary>
        /// Collection of localized descriptions for this Table.
        /// </summary>
        [Browsable(true),DisplayName("Descriptions"),Category("Translations and Perspectives")]
	    public TranslationIndexer TranslatedDescriptions { private set; get; }
        /// <summary>
        /// Collection of localized names for this Table.
        /// </summary>
        [Browsable(true),DisplayName("Names"),Category("Translations and Perspectives")]
	    public TranslationIndexer TranslatedNames { private set; get; }



		/// <summary>
		/// Creates a new Table and adds it to the parent Model.
		/// </summary>
		public Table(Model parent) : base(new TOM.Table()) {
			MetadataObject.Name = parent.MetadataObject.Tables.GetNewName("New Table");
			parent.Tables.Add(this);
			Init();
		}
	
        internal override void RenewMetadataObject()
        {
            var tom = new TOM.Table();
            Handler.WrapperLookup.Remove(MetadataObject);
            MetadataObject.CopyTo(tom);
            MetadataObject = tom;
            Handler.WrapperLookup.Add(MetadataObject, this);
        }


		public Model Parent { 
			get {
				return Handler.WrapperLookup[MetadataObject.Parent] as Model;
			}
		}

		public Table Clone(string newName = null, bool includeTranslations = true) {
		    Handler.BeginUpdate("Clone Table");

				var tom = MetadataObject.Clone();
				tom.Name = Parent.Tables.MetadataObjectCollection.GetNewName(string.IsNullOrEmpty(newName) ? tom.Name + " copy" : newName);
				var obj = new Table(tom);

            Handler.EndUpdate();

            return obj;
		}

		
		/// <summary>
		/// Creates a Table object representing an existing TOM Table.
		/// </summary>
		internal Table(TOM.Table metadataObject) : base(metadataObject)
		{
		}	
    }

	/// <summary>
	/// Collection class for Table. Provides convenient properties for setting a property on multiple objects at once.
	/// </summary>
	public partial class TableCollection: TabularObjectCollection<Table, TOM.Table, TOM.Model>
	{
		public Model Parent { get; private set; }

		public TableCollection(string collectionName, TOM.TableCollection metadataObjectCollection, Model parent) : base(collectionName, metadataObjectCollection)
		{
			Parent = parent;

			// Construct child objects (they are automatically added to the Handler's WrapperLookup dictionary):
			foreach(var obj in MetadataObjectCollection) {
				switch(obj.GetSourceType()) {
				    case TOM.PartitionSourceType.Calculated: new CalculatedTable(obj) { Collection = this }; break;
					default: new Table(obj) { Collection = this }; break;
				}
			}
		}

		[Description("Sets the DataCategory property of all objects in the collection at once.")]
		public string DataCategory {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("DataCategory"));
				this.ToList().ForEach(item => { item.DataCategory = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the Description property of all objects in the collection at once.")]
		public string Description {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("Description"));
				this.ToList().ForEach(item => { item.Description = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the IsHidden property of all objects in the collection at once.")]
		public bool IsHidden {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("IsHidden"));
				this.ToList().ForEach(item => { item.IsHidden = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the ShowAsVariationsOnly property of all objects in the collection at once.")]
		public bool ShowAsVariationsOnly {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("ShowAsVariationsOnly"));
				this.ToList().ForEach(item => { item.ShowAsVariationsOnly = value; });
				Handler.UndoManager.EndBatch();
			}
		}
		[Description("Sets the IsPrivate property of all objects in the collection at once.")]
		public bool IsPrivate {
			set {
				if(Handler == null) return;
				Handler.UndoManager.BeginBatch(UndoPropertyChangedAction.GetActionNameFromProperty("IsPrivate"));
				this.ToList().ForEach(item => { item.IsPrivate = value; });
				Handler.UndoManager.EndBatch();
			}
		}

		public override string ToString() {
			return string.Format("({0} {1})", Count, (Count == 1 ? "Table" : "Tables").ToLower());
		}
	}
}
