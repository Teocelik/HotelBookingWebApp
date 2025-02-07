//Arama kısmına bir terim girilmesi durumunda, AutoComplete metodu kullanılarak API'ye anlık istek atmak ver veri almak için bir js kodu.
// Debounce süresi (milisaniye cinsinden)
const DEBOUNCE_DELAY = 300;

const searchBox = document.getElementById('searchBox');
const resultsContainer = document.getElementById('autocompleteResults');
let debounceTimer = null;

// Input alanında her değişiklikte çalışır
searchBox.addEventListener('input', function () {
    const query = this.value.trim();

    // Eğer sorgu boşsa sonuçları temizle
    if (query === '') {
        resultsContainer.innerHTML = '';
        return;
    }

    // Debounce: hızlı ardışık istekleri engellemek için
    clearTimeout(debounceTimer);
    debounceTimer = setTimeout(() => {
        // API'ye istek at
        fetch(`/api/Search/autoComplete/${encodeURIComponent(query)}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error(`API hatası: ${response.status}`);
                }
                // Metodumuz string döndürdüğü için text() kullanıyoruz
                return response.text();
            })
            .then(data => {
                // Gelen veriyi işleyip, sonuç kısmına yazdırabiliriz.
                // Örneğin, JSON ise JSON.parse(data) ile nesneye çevirebiliriz.
                resultsContainer.innerHTML = data;
            })
            .catch(error => {
                console.error('Hata:', error);
                resultsContainer.innerHTML = '<p>Bir hata oluştu.</p>';
            });
    }, DEBOUNCE_DELAY);
});
