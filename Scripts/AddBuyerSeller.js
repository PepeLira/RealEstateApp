$(document).ready(function () {
    var sellerTemplate = $('#seller-template').html();
    var sellerContainer = $('#seller-container');

    // Add a new seller when the "Add Seller" button is clicked
    $('#add-seller').on('click', function () {
        // Get the index of the last seller
        var lastSellerIndex = sellerContainer.children('.seller-container').length - 1;

        // Clone the seller template and update the input field names
        var newSeller = $(sellerTemplate);
        newSeller.find('input').each(function () {
            var inputName = $(this).attr('name').replace('[0]', '[' + (lastSellerIndex + 1) + ']');
            $(this).attr('name', inputName);
        });

        // Add a click handler to remove the seller when the "Remove Seller" button is clicked
        newSeller.find('.remove-seller').on('click', function () {
            $(this).closest('.seller-container').remove();
        });

        // Append the new seller to the seller container
        sellerContainer.append(newSeller);
    });
});