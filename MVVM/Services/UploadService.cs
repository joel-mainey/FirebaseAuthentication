using System;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Storage;
using AuthenticationTesting2.MVVM.Models;
using Newtonsoft.Json;

namespace AuthenticationTesting2.MVVM.Services
{
    // Service responsible for handling upload functionality
    public class UploadService
    {
        // Property to hold the upload model
        public UploadModel UploadModel;

        // Property to hold the image model
        public ImageModel ImageModel;

        // Private Properties
        private FirebaseClient firebaseClient;
        private FirebaseStorage firebaseStorage;

        // Constructor for handling plant data upload
        public UploadService(UploadModel uploadModel)
        {
            // Initialize UploadModel property
            UploadModel = uploadModel;

            // Initialize Firebase client for database interaction 
            firebaseClient = new FirebaseClient("https://hukutaia-domain-default-rtdb.asia-southeast1.firebasedatabase.app/");
        }

        // Constructor for handlinng image upload
        public UploadService(ImageModel imageModel) 
        {
            // Initialize ImageModel property
            ImageModel = imageModel;

            // Initialize Firebase storage for uplaoding images
            firebaseStorage = new FirebaseStorage("hukutaia-domain.appspot.com");
        }


        // Method to create a new plant entry
        public async Task CreatePlantAsync()
        {
            try
            {
                // Serialize UploadModel to JSON
                string json = JsonConvert.SerializeObject(UploadModel);
                // Post JSON data to Firebase database
                await firebaseClient.Child("Plant").PostAsync(json);
                // Display success message
                await Application.Current.MainPage.DisplayAlert("Success", "Plant entry created!", "Ok");

            }
            catch (Exception ex)
            {
                // Display error message in case of failure
                Console.WriteLine($"Error creating plant: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Error creating plant, please try again later", "Ok");
            }
        }

        // Method to pick an image from the device storage
        public async Task PickImageAsync()
        {
            try
            {
                // Open file picker to select an image
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Select an Image"
                });

                if (result != null) 
                {
                    // Set image stream and file name
                    ImageModel.Stream = await result.OpenReadAsync();
                    ImageModel.FileName = result.FileName;
                    // Display success message
                    await Application.Current.MainPage.DisplayAlert("Image Selected!", $"Image: {result.FileName}", "Ok");
                }
            }
            catch (Exception ex)
            {
                // Display error message in case of failure
                Console.WriteLine($"Error selecting image: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Error selecting image, please try again later", "Ok");
            }
        }

        // Method to upload the selected image to Firebase storage
        public async Task UploadImageAsync()
        {
            try
            {
                // Construct storage path for the image
                var firebaseStoragePath = $"images/{ImageModel.FileName}";
                // Upload image to firebase storage
                await firebaseStorage
                    .Child(firebaseStoragePath)
                    .PutAsync(ImageModel.Stream);
                // Display success message
                await Application.Current.MainPage.DisplayAlert("Image Uploaded!", "Image successfully uploaded!", "Ok");
            }
            catch (Exception ex)
            {
                // Display error message in case of failure
                await Application.Current.MainPage.DisplayAlert("Error", "Error uploading image, please try again later", "Ok");
            }
        }

    }
}
