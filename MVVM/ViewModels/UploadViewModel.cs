using AuthenticationTesting2.MVVM.Models;
using AuthenticationTesting2.MVVM.Services;
using Firebase.Auth;
using PropertyChanged;
using System;
using CommunityToolkit.Mvvm.Input;

namespace AuthenticationTesting2.MVVM.ViewModels
{
    // Represents the view model for the upload view
    [AddINotifyPropertyChangedInterface]
    public class UploadViewModel
    {
        // Model for user upload data
        public UploadModel Upload { get; set; }

        // Model for image upload data
        public ImageModel Image { get; set; }

        // Command for create action
        public Command CreateCommand { get; }

        // Command for Pick image action
        public Command PickImageCommand { get; }

        // Command for Upload image action
        public Command UploadImageCommand { get; }

        // Constructor
        public UploadViewModel()
        {
            // Initialize the login model
            Upload = new UploadModel();
            // Initialize the image model
            Image = new ImageModel();

            // Create an instance of upload service for handling plant data
            var createCommand = new UploadService(Upload);
            // Create an instance of upload service for picking an image
            var pickImageCommand = new UploadService(Image);
            // Create an instance of upload service for uploading an image
            var uploadImageCommand = new UploadService(Image);

            // Assign command to execute the upload service for creating a plant entry
            CreateCommand = new Command(async () => await createCommand.CreatePlantAsync());
            // Assign command to execute the upload service for picking an image
            PickImageCommand = new Command(async () => await pickImageCommand.PickImageAsync());
            // Assign command to execute the upload service for uploading an image
            UploadImageCommand = new Command(async () => await uploadImageCommand.UploadImageAsync());
        }

    }
}
