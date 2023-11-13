import React, { useState } from 'react';
import HomeFunctions from './HomeFunctions';
import Shopping from './Shopping';

function Home() {
    const [categories, setCategories] = useState([]);
    const [selectedCategoryId, setSelectedCategoryId] = useState(null);
    const [productName, setProductName] = useState("");
    const [categoryProduct, setcategoryProduct] = useState([]);
    const [arrCategoryProduct, setArrCategoryProduct] = useState([]);
    // const [categoryQuentity, setCategoryQuentity] = useState(0);

    const {
        SaveCategorySelection,
        SaveProductChange,
        AddProduct,
        GetCategoryQuentity,
        GetProductsByCategoryId,
        UpdateShoppingState
        
    } = HomeFunctions({
        categories,
        setCategories,
        setSelectedCategoryId,
        setProductName,
        // setCategoryQuentity,
        selectedCategoryId,
        setArrCategoryProduct,
        productName,
        setcategoryProduct,
        categoryProduct,
        arrCategoryProduct
    });
    const {
    } = Shopping({
        categories,
        setCategories,
        setSelectedCategoryId,
        setProductName,
        // setCategoryQuentity,
        selectedCategoryId,
        setArrCategoryProduct,
        productName,
        setcategoryProduct,
        categoryProduct,
        arrCategoryProduct
    });
    

    return (
        <div class="imageBackground">
            <>
                <Shopping
                    categories={categories}
                    selectedCategoryId={selectedCategoryId}
                    productName={productName}
                    // categoryQuentity={categoryQuentity}
                    categoryProduct={categoryProduct}
                    arrCategoryProduct={arrCategoryProduct}
                    SaveCategorySelection={SaveCategorySelection}
                    SaveProductChange={SaveProductChange}
                    AddProduct={AddProduct}
                    GetProductsByCategoryId={GetProductsByCategoryId}
                    UpdateShoppingState={UpdateShoppingState} 
                />
            </>
        </div>
    );
}

export default Home;
