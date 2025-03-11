//Arama kısmına bir terim girilmesi durumunda, AutoComplete metodu kullanılarak API'ye anlık istek atmak ver veri almak için js kodu.
// Initialize Lucide icons
lucide.createIcons();

const DEBOUNCE_DELAY = 300;
const searchBox = document.getElementById('searchBox');
const searchButton = document.getElementById('searchButton');
const resultsContainer = document.getElementById('autocompleteResults');
let debounceTimer = null;

async function fetchAutoComplete(query) {
    try {
        const response = await fetch(`/api/AutoComplete/autoComplete?query=${encodeURIComponent(query)}`);
        if (!response.ok) {
            throw new Error(`API error: ${response.status}`);
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching results:', error);
        throw error;
    }
}

function renderResults(response) {
    if (!response?.data || !Array.isArray(response.data) || response.data.length === 0) {
        resultsContainer.innerHTML = `
             <div class="p-3 text-sm text-gray-500">
                 No results found
             </div>
         `;
        return;
    }

    resultsContainer.innerHTML = response.data.map(item => `
         <div class="flex items-center p-3 hover:bg-gray-50 cursor-pointer"
              data-geo-id="${item.geoId}">
             <div class="w-12 h-12 rounded-lg bg-gray-100 flex items-center justify-center">
                 <i data-lucide="map-pin" class="h-6 w-6 text-gray-400"></i>
             </div>
             <div class="ml-4">
                 <div class="text-base font-semibold text-gray-900">
                     ${item.heading?.htmlString.replace(/<\/?[^>]+(>|$)/g, '')}
                 </div>
                 ${item.secondaryTextLineOne?.string ?
            `<div class="text-sm text-gray-500">${item.secondaryTextLineOne.string}</div>`
            : ''}
             </div>
         </div>
     `).join('');

    // Reinitialize icons for newly added elements
    lucide.createIcons();

    // Add click handlers to results
    document.querySelectorAll('#autocompleteResults > div').forEach(div => {
        div.addEventListener('click', async () => {
            const geoId = div.dataset.geoId;
            if (geoId) {
                searchBox.value = div.querySelector('.text-base').textContent.trim();
                resultsContainer.innerHTML = '';
                // You can handle the selection here, e.g., navigate to a details page
                try
                {
                    const response = await fetch(`/search/search?geoId=${geoId}`);
                    if (!response.ok)
                    {
                        throw new Error(`API Hatası: ${response.status}`);
                    }
                    const data = await response.json();
                    console.log('API Yanıtı:', data);
                } catch (error)
                {
                    console.error('API isteği başarısız:', error);
                }

                window.location.href = `/Search/Search`;
            }
        });
    });
}

async function performSearch(query) {
    if (!query) {
        resultsContainer.innerHTML = '';
        return;
    }

    try {
        const response = await fetchAutoComplete(query);
        renderResults(response);
    } catch (error) {
        resultsContainer.innerHTML = `
             <div class="p-3 text-sm text-red-500">
                 An error occurred while searching
             </div>
         `;
    }
}

// Handle input changes with debouncing
searchBox.addEventListener('input', function () {
    const query = this.value.trim();
    clearTimeout(debounceTimer);
    debounceTimer = setTimeout(() => performSearch(query), DEBOUNCE_DELAY);
});

// Handle search button click
searchButton.addEventListener('click', () => {
    performSearch(searchBox.value.trim());
});

// Handle Enter key press
searchBox.addEventListener('keypress', (e) => {
    if (e.key === 'Enter') {
        performSearch(searchBox.value.trim());
    }
});

// Close results when clicking outside
document.addEventListener('click', (e) => {
    if (!searchBox.contains(e.target) &&
        !resultsContainer.contains(e.target) &&
        !searchButton.contains(e.target)) {
        resultsContainer.innerHTML = '';
    }
});

