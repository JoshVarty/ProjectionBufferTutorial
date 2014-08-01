using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Projection;
using Microsoft.VisualStudio.Utilities;

namespace Company.ProjectionBufferTutorial
{
    /// <summary>
    /// Whenever CSharp WpfTextViews are created with the CustomProjectionRole role
    /// this class will run and create a custom text view model for the WpfTextView
    /// </summary>
    [Export(typeof(ITextViewModelProvider)), ContentType("CSharp"), TextViewRole("CustomProjectionRole")]
    internal class ProjectionTextViewModelProvider : ITextViewModelProvider
    {
        public ITextViewModel CreateTextViewModel(ITextDataModel dataModel, ITextViewRoleSet roles)
        {
            //Create a projection buffer based on the specified start and end position.
            var projectionBuffer = CreateProjectionBuffer(dataModel);
            //Display this projection buffer in the visual buffer, while still maintaining
            //the full file buffer as the underlying data buffer.
            var textViewModel = new ProjectionTextViewModel(dataModel, projectionBuffer);
            return textViewModel;

        }

        public IProjectionBuffer CreateProjectionBuffer(ITextDataModel dataModel)
        {
            //retrieve start and end position that we saved in MyToolWindow.CreateEditor()
            var startPosition = (int)dataModel.DataBuffer.Properties.GetProperty("StartPosition");
            var endPosition = (int)dataModel.DataBuffer.Properties.GetProperty("EndPosition");
            var length = endPosition - startPosition;

            //Take a snapshot of the text within these indices.
            var textSnapshot = dataModel.DataBuffer.CurrentSnapshot;
            var trackingSpan = textSnapshot.CreateTrackingSpan(startPosition, length, SpanTrackingMode.EdgeExclusive);

            //Create the actual projection buffer
            var projectionBuffer = ProjectionBufferFactory.CreateProjectionBuffer(
                null
                , new List<object>() { trackingSpan }
                , ProjectionBufferOptions.None
                );
            return projectionBuffer;
        }
        

        [Import]
        public IProjectionBufferFactoryService ProjectionBufferFactory { get; set; }
    }


    internal class ProjectionTextViewModel : ITextViewModel 
    {
        private readonly ITextDataModel _dataModel;
        private readonly IProjectionBuffer _projectionBuffer;
        private readonly PropertyCollection _properties;

        //The underlying source buffer from which the projection was created
        public ITextBuffer DataBuffer
        {
            get
            {
                return _dataModel.DataBuffer;
            }
        }

        public ITextDataModel DataModel
        {
            get
            {
                return _dataModel;
            }
        }

        public ITextBuffer EditBuffer
        {
            get
            {
                return _projectionBuffer;
            }
        }

        // Displays our projection 
        public ITextBuffer VisualBuffer
        {
            get
            {
                return _projectionBuffer;
            }
        }

        public PropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

        public void Dispose()
        {

        }

        public ProjectionTextViewModel(ITextDataModel dataModel, IProjectionBuffer projectionBuffer)
        {
            this._dataModel = dataModel;
            this._projectionBuffer = projectionBuffer;
            this._properties = new PropertyCollection();
        }

        public SnapshotPoint GetNearestPointInVisualBuffer(SnapshotPoint editBufferPoint)
        {
            return editBufferPoint;
        }

        public SnapshotPoint GetNearestPointInVisualSnapshot(SnapshotPoint editBufferPoint, ITextSnapshot targetVisualSnapshot, PointTrackingMode trackingMode)
        {
            return editBufferPoint.TranslateTo(targetVisualSnapshot, trackingMode);
        }

        public bool IsPointInVisualBuffer(SnapshotPoint editBufferPoint, PositionAffinity affinity)
        {
            return true;
        }
    }
}
