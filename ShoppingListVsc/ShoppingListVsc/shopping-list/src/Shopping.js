import React from 'react';
import { Button, FormControl, InputLabel, MenuItem, Select, TextField, Typography } from '@mui/material';

const Shopping = ({ categories, selectedCategoryId, productName, categoryQuentity, categoryProduct, arrCategoryProduct, SaveCategorySelection, SaveProductChange, AddProduct, GetProductsByCategoryId }) => {
  return (
    <div className="allPage">
      <Typography variant="h1">Home Page</Typography>
      <FormControl>
        <InputLabel id="category-select-label">Select Category</InputLabel>
        <Select
          labelId="category-select-label"
          id="category-select"
          value={selectedCategoryId}
          onChange={(e) => SaveCategorySelection(e.target.value)}
        >
          {categories.map((category) => (
            <MenuItem key={category.id} value={category.id}>
              {category.name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
      <Typography variant="h2">הכנס שם מוצר:</Typography>
      <TextField id="product-name" label="Product Name" value={productName} onChange={SaveProductChange} />
      <Button variant="contained" onClick={AddProduct}>
        הוסף
      </Button>
      <Typography variant="body1">{categoryQuentity}</Typography>

      {categories.map((category) => (
        <div key={category.id}>
          <Typography variant="body1">
            {category.name} {category.sum}
          </Typography>

        </div>
      ))}
    </div>
  );
};

export default Shopping;
