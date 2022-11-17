module.exports = {
  testEnvironment: 'jsdom',
  testMatch: [
    '**/*.test.ts',
    '**/*.test.tsx'
  ],
  moduleNameMapper: {
    "\\.(css|svg)$": '../jest.mock.js'
  }
};
