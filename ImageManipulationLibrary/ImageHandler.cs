using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// COMP3304 Assessment - by Ben Rose & Luke Mitchell
/// </summary>
namespace COMP3304Assessment
{
    /// <summary>
    /// Responsible for retreiving the current image and setting the Form's PictureBox Image property to that image.
    /// </summary>
    public class ImageHandler : IImageGetter, IImageSetter, IEventPublisher
    {
        // DECLARE an IFilePathGetter interface to store a reference to the FilePathHandler instance, call it '_filePathHandler':
        private IFilePathGetter _filePathHandler;
        // DECLARE an int to keep track of which image to display, call it '_imgIndex':
        private int _imgIndex;
        // DECLARE an IModel interface to store a reference to the Model instance, call it '_model':
        private IModel _model;
        // DECLARE an event to store image event handlers, call it '_imageEvent':
        private event EventHandler<ImageEventArgs> _imageEvent;

        private Size _imageSize;

        public ImageHandler(IFilePathGetter filePathHandler, IModel model)
        {
            // INSTANTIATE the local '_filePathHandler' with the passed reference
            _filePathHandler = filePathHandler;

            // INSTANTIATE the local 'imgIndex' to 0
            _imgIndex = 0;

            // INSTANTIATE the local '_model' with the passed reference
            _model = model;
        }

        /// <summary>
        /// Implements RetrieveImageDelegate - Gets the image and triggers the OnNewImage event
        /// </summary>
        //public void RetrieveImage(Size size)
        //{
        //    _imageSize = size;

        //    Image img = GetImage();
        //    // If image was retrieved, trigger event
        //    if (img != null)
        //    {
        //        OnNewImage(img);
        //    }
        //}

        /// <summary>
        /// Increment '_imgIndex' value and dispay image
        /// </summary>
        public void NextImage()
        {
            // Increment the 'imgIndex' value 
            _imgIndex++;

            Image img = GetImage();
            // If image was retrieved, trigger event
            if (img != null)
            {
                OnNewImage(img);
            }
        }

        /// <summary>
        /// Decrement '_imgIndex' value and dispay image
        /// </summary>
        public void PreviousImage()
        {
            // Decrement the 'imgIndex' value 
            _imgIndex--;

            Image img = GetImage();
            // If image was retrieved, trigger event
            if (img != null)
            {
                OnNewImage(img);
            }
        }

        /// <summary>
        /// Retrieve file path from FilePathHandler by an index, using that file path retrieve an Image from model then set '_pictureBoxes' image to it.
        /// </summary>
        private Image GetImage()
        {
            // DECLARE & INSTANIATE an temporary Image variable to null. Call it 'newImage':
            Image newImage = null;

            // DECLARE & INSTANIATE a temporary string variable. Give it the file path returned from the GetFilePath method after passing current _imgIndex. Call it 'filePath':
            string filePath = _filePathHandler.GetFilePath(_imgIndex);

            // Check if a filePath was found for that index
            if (filePath != null)
            {
                // Call getImage method, passing filePath and _pictureBox's width and height properties, save result in 'newImage'
                newImage = _model.getImage(filePath, _imageSize.Width, _imageSize.Height);
            }

            // If the 'newImage' value is not null an image was found
            if (newImage != null)
            {
                // Apply 'newImage' to '_pictureBox's Image property
                return newImage;
            }
            else if (_imgIndex < 0)
            {
                // Set index to 0 to prevent index going out of bounds
                _imgIndex = 0;
            }
            else
            {
                // Decrement the 'imgIndex' value to prevent index going out of bounds
                _imgIndex--;
            }

            return null;
        }

        /// <summary>
        /// Called when new image is recieved
        /// </summary>
        /// <param name="data">The image</param>
        //private void OnNewImage(Image data)
        //{
        //    ImageEventArgs imageArgs = new ImageEventArgs(data);
        //    _imageEvent(this, imageArgs);
        //}

        #region Implements Event Publisher
        /// <summary>
        /// Subscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Subscribe(EventHandler<ImageEventArgs> listener)
        {
            _imageEvent += listener;
        }

        /// <summary>
        /// Unsubscribe a listener to image events
        /// </summary>
        /// <param name="listener">references the listener method</param>
        public void Unsubscribe(EventHandler<ImageEventArgs> listener)
        {
            _imageEvent -= listener;
        }
        #endregion
    }
}
