using Microsoft.SharePoint.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.Samples.Models
{

    [ContentType(Name = "アイテム", Id = "0x01")]
    public class Item : ITrackEntityState, ITrackOriginalValues, INotifyPropertyChanged, INotifyPropertyChanging
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanging(PropertyChangingEventArgs e)
        {
            var handler = this.PropertyChanging;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        protected void OnPropertyChanging(string propertyName, object value)
        {
            if (this.OriginalValues.ContainsKey(propertyName) != true)
            {
                this.OriginalValues.Add(propertyName, value);
            }
            this.OnPropertyChanging(new PropertyChangingEventArgs(propertyName));
        }

        private int? id;

        [Column(Name = "ID", Storage = "id", ReadOnly = true, FieldType = "Counter")]
        public virtual int? ID
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.OnPropertyChanging("ID", this.ID);
                    this.id = value;
                    this.OnPropertyChanged("ID");
                }
            }
        }

        private string title;

        [Column(Name = "Title", Storage = "title", Required = true, FieldType = "Text")]
        public virtual string Title
        {
            get { return this.title; }
            set
            {
                if (this.title != value)
                {
                    this.OnPropertyChanging("Title", this.Title);
                    this.title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        private int? version;

        [Column(Name = "owshiddenversion", Storage = "version", ReadOnly = true, FieldType = "Integer")]
        public virtual int? Version
        {
            get { return this.version; }
            set
            {
                if (this.version != value)
                {
                    this.OnPropertyChanging("Version", this.Version);
                    this.version = value;
                    this.OnPropertyChanged("Version");
                }
            }
        }

        private EntityState entityState;

        public virtual EntityState EntityState
        {
            get { return this.entityState; }
            set
            {
                if (this.entityState != value)
                {
                    this.OnPropertyChanging("EntityState", this.EntityState);
                    this.entityState = value;
                    this.OnPropertyChanged("EntityState");
                }
            }
        }

        public IDictionary<string, object> OriginalValues { get; private set; }

        public Item()
        {
            this.OriginalValues = new Dictionary<string, object>();
        }

    }

}
