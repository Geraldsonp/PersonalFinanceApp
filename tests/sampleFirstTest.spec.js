import { test, expect } from '@playwright/test';

test('has correct title', async ({ page }) => {
  await page.goto('http://localhost:5031/');
  await page.getByRole('link', { name: 'Overview' }).click();

  //delay 500ms
  await page.waitForTimeout(500);

  await expect(page.locator('div').filter({ hasText: /^Overview$/ })).toBeVisible();
  await expect(page.getByText('Current Balance $')).toBeVisible();
  await expect(page.getByRole('main')).toContainText('Current Balance');
});

test('Has Savings Page', async ({ page }) => {
  await page.goto('http://localhost:5031/');
  await expect(page.getByRole('link', { name: 'Savings' })).toBeVisible();
  await page.getByRole('link', { name: 'Savings' }).click();
  await expect(page.getByRole('main')).toContainText('Savings');
  await expect(page.getByRole('button', { name: '+ Add New Pot' })).toBeVisible();
});


test('Opens Create Pots Modal', async ({ page }) => {
  await page.goto('http://localhost:5031/');
  await expect(page.getByRole('link', { name: 'Savings' })).toBeVisible();
  await page.getByRole('link', { name: 'Savings' }).click();
  await expect(page.getByRole('button', { name: '+ Add New Pot' })).toBeVisible();
  await page.getByRole('button', { name: '+ Add New Pot' }).click();
  await expect(page.getByText('Add New Pot Create a pot to')).toBeVisible();
});


test('Adds Pot on submit', async ({ page }) => {
  await page.goto('http://localhost:5031/');
  await expect(page.getByRole('link', { name: 'Savings' })).toBeVisible();
  await page.getByRole('link', { name: 'Savings' }).click();
  await expect(page.getByRole('button', { name: '+ Add New Pot' })).toBeVisible();
  await page.getByRole('button', { name: '+ Add New Pot' }).click();
  await expect(page.getByText('Add New Pot Create a pot to')).toBeVisible();
  await page.getByPlaceholder('e.g. Rainy Days').click();
  await page.getByPlaceholder('e.g. Rainy Days').fill('Test Play');
  await page.getByPlaceholder('e.g. 2000').click();
  await page.getByPlaceholder('e.g. 2000').fill('1500');
  await page.getByRole('button', { name: 'Select an option' }).click();
  await page.locator('div').filter({ hasText: /^Blue$/ }).click();
  await page.getByRole('button', { name: 'Add Pot' }).click();
  await expect(page.getByRole('main')).toContainText('Test Play');
  await expect(page.getByRole('main')).toContainText('Taget of $1,500.00');
});



test('Can Delete', async ({ page }) => {
  await page.goto('http://localhost:5031/Savings');
  await page.locator('div:nth-child(6) > .bg-white > div > div > .relative > .text-gray-500').click();
  await page.getByRole('button', { name: 'Delete' }).click();
  await expect(page.getByText('Delete \'Savings\'? Are you')).toBeVisible();
  await expect(page.getByRole('button', { name: 'Yes, Confirm Deletion' })).toBeVisible();
  await page.getByRole('button', { name: 'Yes, Confirm Deletion' }).click();
  await expect(page.getByRole('main')).not.toContainText('Test Play');
  await expect(page.getByRole('main')).not.toContainText('Taget of $1,500.00');
});