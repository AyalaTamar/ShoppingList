import axios from 'axios';
import React, { useEffect, useState } from 'react';

const HomeFunctions = ({
    categories,
    setCategories,
    selectedCategoryId,
    setSelectedCategoryId,
    setArrCategoryProduct,
    productName,
    setProductName,
    // categoryQuentity,
    // setCategoryQuentity,
    setcategoryProduct,
    categoryProduct,
    arrCategoryProduct,
    UpdateShoppingState,
}) => {
    useEffect(() => {
        GetAllCategoriesAsync();
    }, []);
    useEffect(() => {
        // Trigger FillArrayProducts whenever categories change
        FillArrayProducts();
    }, [categories]);
    const GetAllCategoriesAsync = async () => {
        try {
            const { data } = await axios.get('https://localhost:7042/api/category')
            setCategories(data);
            console.log("all data:", data);
            if (data.length > 0) {
                setSelectedCategoryId(data[0].id);
            }
            FillArrayProducts()
        }
        catch (error) {
            console.error("Error fetching data:", error);
        }

    }
    const SaveCategorySelection = (categoryId) => {
        setSelectedCategoryId(categoryId);
        console.log(categoryId)
    }
    const SaveProductChange = (e) => {
        setProductName(e.target.value);
    }
    const AddProduct = async () => {
        try {
            const { data } = await axios.post(`https://localhost:7042/api/customersItem/AddOrUpdateItemForCustomerAsync?customerId=1&categoryId=${selectedCategoryId}&itemName=${productName}`);
            console.log("Product added successfully");
            window.location.reload();
            // Perform any additional actions after successfully adding the product
        } catch (error) {
            console.error("Error adding product:", error);
            // Handle the error appropriately
        }
    };
    const GetProductsByCategoryId = async (categoryId) => {
        try {
            const { data } = await axios.get(`https://localhost:7042/api/customersItem/GetItemsByCategoryIdForCustomerAsync?categoryId=${categoryId}&customerId=1`);
            setcategoryProduct(data);
            console.log("pppppp", data);
            return data
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };
    const FillArrayProducts = async () => {

        try {
            console.log(categories + "aaaaaaaaaaaaaaal categories fill");
            const categoryProductsTmp = {};
            let i = 0;
            if (categories && categories.length > 0) {
                await Promise.all(categories.map(async (category) => {
                    const categoryId = category.id;

                    const data = await GetProductsByCategoryId(categoryId);
                    console.log("the items", data);
                    categoryProductsTmp[i] = {
                        nameCategory: category.name,
                        data: data,
                    };
                    i++;
                }));
                setArrCategoryProduct(categoryProductsTmp);
                console.log("arrCategoryProduct", categoryProductsTmp);
                console.log("check!!" + arrCategoryProduct.data.name)
            } else {
                console.warn("Categories array is undefined or empty");
            }
        } catch (error) {
            console.error("Error filling array with products:", error);
        }
        console.log("plissssssssssssssssssss" + arrCategoryProduct)
    };

    return {
        SaveCategorySelection,
        SaveProductChange,
        AddProduct,
        // GetCategoryQuentity,
        UpdateShoppingState
        
    };
};
export default HomeFunctions;