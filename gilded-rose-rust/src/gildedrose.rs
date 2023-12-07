use std::fmt::{self, Display};

use std::cell::RefCell;

use crate::callback::ItemHandler;
pub struct Item {
    pub name: String,
    pub sell_in: i32,
    pub quality: i32,
}

impl Item {
    pub fn new(name: impl Into<String>, sell_in: i32, quality: i32) -> Item {
        Item {
            name: name.into(),
            sell_in,
            quality,
        }
    }
}

impl Display for Item {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "{}, {}, {}", self.name, self.sell_in, self.quality)
    }
}

pub struct GildedRose {
    pub items: RefCell<Vec<Item>>,
    pub item_handler: ItemHandler,
}

impl GildedRose {
    pub fn new(items: Vec<Item>) -> GildedRose {
        let item_handler: ItemHandler = ItemHandler::new();
        GildedRose {
            items: RefCell::new(items),
            item_handler,
        }
    }
}

impl GildedRose {
    pub fn update_quality(&mut self) {
        let items_ref = self.items.get_mut();
        for i in 0..items_ref.len() {
            self.item_handler.call_item_function(&mut items_ref[i])
        }
    }
}
