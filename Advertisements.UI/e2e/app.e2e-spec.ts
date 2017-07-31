import { Advertisements.UIPage } from './app.po';

describe('advertisements.ui App', () => {
  let page: Advertisements.UIPage;

  beforeEach(() => {
    page = new Advertisements.UIPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
