#![allow(unused)]

use crate::Item;
use std::cmp::{max, min};
use std::collections::HashMap;

const ITEM_DEFAULT_NAME: &'static str = "default_item";

type Callback = fn(&mut Item);

pub struct ItemHandler {
    item_functions: HashMap<String, Callback>,
}

impl ItemHandler {
    fn add_item_function(&mut self, func_name: String, func: Callback) {
        self.item_functions.insert(func_name, func);
    }
}

impl ItemHandler {
    pub fn call_item_function(&mut self, item: &mut Item) {
        if self.item_functions.contains_key(&item.name) {
            self.item_functions[&item.name](item);
        } else {
            self.item_functions[ITEM_DEFAULT_NAME](item);
        }
    }
}

fn default_item_callback(item: &mut Item) {
    item.sell_in = max(0, item.sell_in - 1);
    if (item.sell_in == 0) {
        item.quality -= 1;
        item.quality = max(0, item.quality);
    }
}

fn aged_brie_callback(item: &mut Item) {
    item.sell_in = max(0, item.sell_in - 1);
    item.quality += if item.sell_in > 0 { 1 } else { 2 };
    item.quality = min(50, item.quality);
}

fn sulfuras_callback(item: &mut Item) {
    item.sell_in = 0;
    item.quality = 80;
}

fn backstage_passes_callback(item: &mut Item) {
    item.sell_in = max(0, item.sell_in - 1);
    if (item.sell_in == 0) {
        item.quality = 0;
    } else {
        item.quality += if (item.sell_in <= 5) {
            3
        } else if (item.sell_in <= 10) {
            2
        } else {
            1
        };
        item.quality = min(50, item.quality);
    }
}

fn conjured_callback(item: &mut Item) {
    item.sell_in = max(0, item.sell_in - 2);
    if (item.sell_in == 0) {
        item.quality -= 1;
        item.quality = max(0, item.quality);
    }
}

impl ItemHandler {
    pub fn new() -> ItemHandler {
        let mut item_functions = HashMap::<String, Callback>::default();
        item_functions.insert(ITEM_DEFAULT_NAME.to_owned(), default_item_callback);
        item_functions.insert("Aged Brie".to_string(), aged_brie_callback);
        item_functions.insert("Sulfuras, Hand of Ragnaros".to_string(), sulfuras_callback);
        item_functions.insert(
            "Backstage passes to a TAFKAL80ETC concert".to_string(),
            backstage_passes_callback,
        );
        item_functions.insert("Conjured Mana Cake".to_string(), conjured_callback);

        ItemHandler { item_functions }
    }
}
